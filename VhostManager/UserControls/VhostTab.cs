using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace VhostManager
{
    public partial class VhostTab : UserControl
    {
        private Timer _AnimationTimer;
        private InstantCopier _FileSync;
        private bool _IsSyncInProgress;
        private FileSystemWatcher _LocalFolderWatcher;

        public VhostTab(VhostDetails vhostDetails, ConnectionInfo sshInfo, string sshPassword, FormMain parentForm)
        {
            InitializeComponent();
            this.MainForm = parentForm;
            this.VhostInfo = vhostDetails;
            this.SSHConnectionInfos = sshInfo;
            this.ConnexionPassword = sshPassword;
            this.SyncHistory = new List<KeyValuePair<DateTime, string>>();            
            StartLoadingIfValid();

            // Tooltip bouton de sync.
            var toolTipSync = new ToolTip();
            toolTipSync.ShowAlways = true;
            string tipText = "Synchroniser le dossier local avec le vhost...";
            toolTipSync.SetToolTip(this.buttonSync, tipText);
        }
        

        #region Properties
        public delegate void VhostDeletedDelegate();
        public event VhostDeletedDelegate VhostDeleted;

        public FormMain MainForm { get; set; }

        public string UncPathBase
        {
            get
            {
                return string.Format(@"\\{0}\vhosts\{1}\httpdocs", this.SSHConnectionInfos.Host, this.VhostInfo.Nom);
            }
        }

        private Timer AnimationTimer
        {
            get
            {
                if (_AnimationTimer == null)
                    _AnimationTimer = new Timer();

                return _AnimationTimer;
            }
        }

        private string ConnexionPassword { get; set; }

        private InstantCopier FileSync
        {
            get
            {
                if (_FileSync == null)
                {
                    _FileSync = new InstantCopier(this.VhostInfo.CheminLocal, this.UncPathBase, this.SSHConnectionInfos.Username, this.ConnexionPassword);
                }

                return _FileSync;
            }
        }

        private bool IsSyncInProgress
        {
            get
            {
                return IsSyncInProgress;
            }

            set
            {
                this.buttonSync.Invoke((MethodInvoker)(() =>
                {
                    //this.progressBarSync.Visible = value;
                    AnimateSyncButton(value);
                    this.buttonSync.Enabled = !value;
                }));

                _IsSyncInProgress = value;
            }
        }

        private FileSystemWatcher LocalFolderWatcher
        {
            get
            {
                if (_LocalFolderWatcher == null)
                {
                    _LocalFolderWatcher = new FileSystemWatcher();

                    _LocalFolderWatcher.Path = this.VhostInfo.CheminLocal;
                    _LocalFolderWatcher.IncludeSubdirectories = true;
                    _LocalFolderWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                    _LocalFolderWatcher.Filter = "*.*";
                    _LocalFolderWatcher.Changed += new FileSystemEventHandler(LocalFileChanged);
                    _LocalFolderWatcher.Created += new FileSystemEventHandler(LocalFileChanged);
                    _LocalFolderWatcher.Deleted += new FileSystemEventHandler(LocalFileChanged);
                    _LocalFolderWatcher.Renamed += new RenamedEventHandler(LocalFileChanged);
                }

                return _LocalFolderWatcher;
            }
        }

        private FormLogs LogsForm { get; set; }

        private ConnectionInfo SSHConnectionInfos { get; set; }

        private List<KeyValuePair<DateTime, string>> SyncHistory { get; set; }

        private SyncManager _syncManager;

        private SyncManager SyncManagerVhost
        {
            get
            {
                if (_syncManager == null)
                {
                    _syncManager = new SyncManager(this.VhostInfo.CheminLocal, this.SSHConnectionInfos.Host, this.VhostInfo.Nom);
                }
                return _syncManager;
            }
        }

        private VhostDetails VhostInfo { get; set; }
        #endregion

        #region Interface Initialization
        private void LoadDetails()
        {
            this.linkLabelNDD.Text = this.VhostInfo.Nom;
            this.linkLabelCheminLocal.Text = this.VhostInfo.CheminLocal;

            // developpement / production
            if (HostsFileManager.IsHostNameExist(this.VhostInfo.Nom))
            {
                this.radioButtonDev.Checked = true;
                this.radioButtonProd.Checked = false;
            }
            else
            {
                this.radioButtonDev.Checked = false;
                this.radioButtonProd.Checked = true;
            }

            // Etat de synchronisation
            this.CheckSync();

            // Verifie l'acces au fichier hosts
            if (!HostsFileManager.HasAcces())
                this.panelUnlockHost.Visible = true;
        }

        private void StartLoadingIfValid()
        {
            bool isLocalValid = true;
            bool isDistantValid = true;

            string errorMessage = string.Empty;

            string uncPath = this.UncPathBase;

            var bw = new BackgroundWorker();
            // DEMARRE
            bw.DoWork += (s, args) =>
            {
                if (!Directory.Exists(VhostInfo.CheminLocal))
                {
                    isLocalValid = false;
                }

                try
                {
                    using (GetNetworkConnection(uncPath))
                    {
                        DirectoryInfo di = new DirectoryInfo(uncPath);
                        if (!di.Exists)
                        {
                            isDistantValid = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    isDistantValid = false;
                }
            };

            // TERMINE
            bw.RunWorkerCompleted += (s, args) =>
            {
                if (isLocalValid && isDistantValid)
                {
                    this.StartWatchLocalFolder();
                    this.LoadDetails();
                }

                if (!isLocalValid)
                    this.labelErreur.Text = string.Format("Le chemin local n'est pas valide : {0}", VhostInfo.CheminLocal);
                if (!isDistantValid)
                {
                    this.labelErreur.Text = string.Format("Impossible de se connecter au dossier du vhost linux : {0}", uncPath);
                    this.MainForm.StatusBarLabel.ForeColor = Color.Red;
                    this.MainForm.StatusBarLabel.Text = errorMessage;
                }
            };

            // LANCE
            bw.RunWorkerAsync();
        }
        #endregion

        #region Vhost
        /// <summary>
        /// Supprime les dossiers du vhost sur le serveur
        /// et la ligne du fichier hosts pour le dev
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSuppresion_Click(object sender, EventArgs e)
        {
            this.buttonSuppresion.Text = "Supression en cours...";
            this.buttonSuppresion.Enabled = false;

            var bw = new BackgroundWorker();
            var syncDirection = this.MainForm.SyncDirection;

            // DEMARRE
            bw.DoWork += (s, args) =>
            {
                try
                {
                    VhostsFileManager.DeleteVhosts(this.VhostInfo.Nom, this.SSHConnectionInfos);
                    HostsFileManager.DeleteHostName(this.VhostInfo.Nom);
                }
                catch (Exception ve)
                {
                    this.MainForm.Invoke((MethodInvoker)(() =>
                    {
                        this.MainForm.StatusBarLabel.ForeColor = Color.Red;
                        this.MainForm.StatusBarLabel.Text = ve.Message;
                    }));
                }
            };

            // TERMINE
            bw.RunWorkerCompleted += (s, args) =>
            {
                //this.buttonSuppresion.Text = "Supprimer ce Vhost";
                //this.buttonSuppresion.Enabled = true;

                // delegué pour dire de recharger les onglets
                this.VhostDeleted();
            };

            // LANCE
            bw.RunWorkerAsync();
        }
        #endregion

        #region Direct Links
        private void linkLabelCheminLocal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(this.VhostInfo.CheminLocal))
                Process.Start(string.Format("{0}", this.VhostInfo.CheminLocal));
        }        

        private void linkLabelNDD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = string.Format("http://www.{0}", ((LinkLabel)sender).Text);
            System.Diagnostics.Process.Start(url);
        }
        #endregion

        #region Manage MySQL
        private void linkLabelMySQL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = string.Format("http://{0}/phpmyadmin/", this.SSHConnectionInfos.Host);
            System.Diagnostics.Process.Start(url);
        }
        #endregion

        #region Log Monitor
        private void linkLabelLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.LogsForm == null || this.LogsForm.IsDisposed)
                this.LogsForm = new FormLogs(this.VhostInfo.Nom, this.SSHConnectionInfos);

            this.LogsForm.Show();
            this.LogsForm.StartPosition = FormStartPosition.CenterScreen;
            this.LogsForm.BringToFront();
        }
        #endregion

        #region NetBeans Project
        private void linkLabelNetBeans_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string netbeansInstallFolder64 = string.Empty;
            string netbeansInstallFolder32 = string.Empty;

            var userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string netbeansConfPath = string.Format("{0}\\.nbi\\registry.xml", userPath);
            var xmlLocal = XDocument.Load(netbeansConfPath);

            var properties = from elm in xmlLocal.Descendants("components").SelectMany(d => d.Descendants("product"))
                             where (string)elm.Attribute("uid") == "nb-base"
                             select elm;

            var key = (from element in properties.Descendants("property")
                       where (string)element.Attribute("name") == "installation.location.windows"
                       select element).FirstOrDefault();

            if (key != null)
            {
                netbeansInstallFolder64 = key.Value + @"\bin\netbeans64.exe";
                netbeansInstallFolder32 = key.Value + @"\bin\netbeans.exe";
            }

            if ((!string.IsNullOrEmpty(netbeansInstallFolder64) || !string.IsNullOrEmpty(netbeansInstallFolder32)) && (File.Exists(netbeansInstallFolder64) || File.Exists(netbeansInstallFolder32)))
            {
                if (!NetbeansProjectManager.IsProjectExist(VhostInfo.CheminLocal))
                {
                    NetbeansProjectManager.CreateProject(VhostInfo.CheminLocal, VhostInfo.Nom);
                }

                if (File.Exists(netbeansInstallFolder64))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = netbeansInstallFolder64;
                    process.StartInfo.Arguments = string.Format(@"--open ""{0}""", VhostInfo.CheminLocal);
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    process.Start();
                }
                else
                {
                    Process process = new Process();
                    process.StartInfo.FileName = netbeansInstallFolder32;
                    process.StartInfo.Arguments = string.Format(@"--open ""{0}""", VhostInfo.CheminLocal);
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    process.Start();
                }
            }
            else
            {
                MessageBox.Show(this, "NetBeans ne semble pas etre installé.", "NetBeans introuvable...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Sync History
        private void linkLabelHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dialog = new SyncHistoryForm(this.SyncHistory, this.VhostInfo.Nom);
            dialog.ShowDialog();
        }
        #endregion

        #region Hosts
        /// <summary>
        /// Gestion de la mise en production.
        /// Basiquement, ecrit dans le fichier host le nom d'hote
        /// lorsque developpement est selectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_Click(object sender, EventArgs e)
        {
            if (this.radioButtonDev.Checked)
            {
                string IP = this.SSHConnectionInfos.Host;
                IPAddress address;
                if (!IPAddress.TryParse(IP, out address))
                {
                    foreach (IPAddress ipAddress in Dns.GetHostAddresses(IP))
                    {
                        IP = ipAddress.ToString();
                    }
                }

                try
                {
                    HostsFileManager.AddHostName(this.VhostInfo.Nom, this.VhostInfo.SousDomaines, IP);
                }
                catch (Exception ex)
                {
                    this.MainForm.StatusBarLabel.ForeColor = Color.Red;
                    this.MainForm.StatusBarLabel.Text = ex.Message;
                }
            }
            else
            {
                try
                {
                    HostsFileManager.DeleteHostName(this.VhostInfo.Nom);
                }
                catch (Exception ex)
                {
                    this.MainForm.StatusBarLabel.ForeColor = Color.Red;
                    this.MainForm.StatusBarLabel.Text = ex.Message;
                }
            }
        }

        private void linkLabelUnlockHosts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string pathToApp = AppDomain.CurrentDomain.BaseDirectory + "\\HostsFileUnlocker.exe";
            Process process = new Process();
            process.StartInfo.FileName = pathToApp;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();
            int code = process.ExitCode;
            //if (code == -1)
            //{
            //    this.MainForm.StatusBarLabel.ForeColor = Color.Red;
            //    this.MainForm.StatusBarLabel.Text = "Impossible de débloquer le fichier hosts";
            //}

            if (!HostsFileManager.HasAcces())
            {
                this.MainForm.StatusBarLabel.ForeColor = Color.Red;
                this.MainForm.StatusBarLabel.Text = "Impossible de débloquer le fichier hosts";
            }
            else
            {
                this.panelUnlockHost.Visible = true;
            }
        }
        #endregion

        #region Synchronisation
        private void StartSync()
        {
            this.IsSyncInProgress = true;            
            //this.StoptWatchLocalFolder();
            string errorMessage = string.Empty;

            this.labelSync.Invoke((MethodInvoker)(() =>
            {
                labelSync.ForeColor = Color.Orange;
                labelSync.Text = string.Format("En cours de synchronisation...");
            }));

            this.SyncHistory.Add(new KeyValuePair<DateTime, string>(DateTime.Now, string.Format("Debut de synchronisation")));

            var syncDirection = this.MainForm.SyncDirection;
            Microsoft.Synchronization.SyncOperationStatistics statsSync = null;
            var bw = new BackgroundWorker();

            // DEMARRE
            bw.DoWork += (s, args) =>
            {
                try
                {
                    statsSync = this.SyncManagerVhost.Synchronize(
                        this.SSHConnectionInfos.Username,
                        this.ConnexionPassword,
                        syncDirection);
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }
            };

            // TERMINE
            bw.RunWorkerCompleted += (s, args) =>
            {
                if (statsSync != null)
                {
                    int nombreChangements = statsSync.UploadChangesFailed;
                    if (nombreChangements > 0)
                    {
                        this.labelSync.Invoke((MethodInvoker)(() =>
                        {
                            labelSync.ForeColor = Color.Red;
                            labelSync.Text = string.Format("{0} fichiers non synchronisé!", nombreChangements);
                        }));
                    }
                    else
                    {
                        this.labelSync.Invoke((MethodInvoker)(() =>
                        {
                            labelSync.ForeColor = Color.Green;
                            labelSync.Text = string.Format("Synchronisé!");
                        }));
                    }

                    this.SyncHistory.Add(new KeyValuePair<DateTime, string>(DateTime.Now, string.Format("Fin de Sync. {0} fichiers non synchronisés", nombreChangements)));
                }
                else
                {
                    this.SyncHistory.Add(new KeyValuePair<DateTime, string>(DateTime.Now, string.Format("Fin de Syn. Erreur")));
                    labelSync.ForeColor = Color.Red;
                    labelSync.Text = string.Format("Dossier en cours de sync. par un autre utilisateur!");
                    this.MainForm.StatusBarLabel.ForeColor = Color.Red;
                    this.MainForm.StatusBarLabel.Text = errorMessage.Replace(Environment.NewLine, "");
                }

                this.IsSyncInProgress = false;
                //this.StartWatchLocalFolder();
            };

            // LANCE
            bw.RunWorkerAsync();
        }

        //void SyncManagerVhost_SessionProgress(object sender, SyncFileEventArg e)
        //{
        //    if (e.TotalFiles > e.TotalProcessed)
        //    {
        //        int percentageComplete = e.TotalProcessed / e.TotalFiles * 100;
        //        this.progressBarSync.Invoke((MethodInvoker)(() =>
        //                 {
        //                     this.progressBarSync.Step = percentageComplete;
        //                 }));
        //    }
        //    else
        //    {
        //        this.progressBarSync.Step = 100;
        //    }
        //}

        private void CheckSync()
        {
            this.IsSyncInProgress = true;
            //this.StoptWatchLocalFolder();
            string errorMessage = string.Empty;

            labelSync.ForeColor = Color.Orange;
            labelSync.Text = string.Format("En cours de calcul...");
            //this.buttonSync.Visible = false;

            Microsoft.Synchronization.SyncOperationStatistics statsSync = null;
            var bw = new BackgroundWorker();

            var syncDirection = this.MainForm.SyncDirection;
            this.SyncHistory.Add(new KeyValuePair<DateTime, string>(DateTime.Now, "Début de calcul..."));

            // DEMARRE
            bw.DoWork += (s, args) =>
            {
                try
                {
                    statsSync = this.SyncManagerVhost.DetectChanges(
                        this.SSHConnectionInfos.Username,
                        this.ConnexionPassword,
                        syncDirection);
                }
                catch (Exception ex)
                {
                    errorMessage = "Le synchronisation n'a pas pu démarrer : " + ex.Message;
                }
            };

            // TERMINE
            bw.RunWorkerCompleted += (s, args) =>
            {
                if (statsSync != null)
                {
                    int nombreChangements = statsSync.UploadChangesTotal;
                    if (nombreChangements > 0)
                    {
                        labelSync.ForeColor = Color.Red;
                        labelSync.Text = string.Format("{0} fichiers à synchroniser!", nombreChangements);
                    }
                    else
                    {
                        labelSync.ForeColor = Color.Green;
                        labelSync.Text = string.Format("Synchronisé!");
                    }

                    this.SyncHistory.Add(new KeyValuePair<DateTime, string>(DateTime.Now, string.Format("Fin de calcul. {0} fichiers a sync.", nombreChangements)));
                }
                else
                {
                    this.SyncHistory.Add(new KeyValuePair<DateTime, string>(DateTime.Now, string.Format("Fin de calcul. Erreur")));
                    labelSync.ForeColor = Color.Red;
                    labelSync.Text = string.Format("Dossier en cours de sync. par un autre utilisateur!");
                    this.MainForm.StatusBarLabel.ForeColor = Color.Red;
                    this.MainForm.StatusBarLabel.Text = errorMessage.Replace(Environment.NewLine, "");
                }

                //this.buttonSync.Visible = true;
                //toolTipSync.SetToolTip(this.buttonSync, string.Empty);

                this.IsSyncInProgress = false;
                //this.StartWatchLocalFolder();
            };

            // LANCE
            bw.RunWorkerAsync();
        }

        private void buttonSync_Click(object sender, EventArgs e)
        {
            string errorMessage = "La synchronisation n'a pas pu démarrer : ";

            try
            {
                this.StartSync();
            }
            catch (Exception ex)
            {
                this.MainForm.StatusBarLabel.ForeColor = Color.Red;
                this.MainForm.StatusBarLabel.Text = (errorMessage + ex.Message).Replace(Environment.NewLine, "");
            }
        }

        private void AnimateSyncButton(bool start)
        {
            if (start)
            {
                this.AnimationTimer.Interval = 500;
                this.AnimationTimer.Tick += (sender, args) =>
                {
                    int index = 0;
                    if (this.AnimationTimer.Tag != null)
                    {
                        index = (int)this.AnimationTimer.Tag;
                        if (index >= 4)
                            index = 0;
                    }

                    var listImage = new List<Bitmap> { Properties.Resources.sync1, Properties.Resources.sync2, Properties.Resources.sync3, Properties.Resources.sync4 };

                    this.buttonSync.BackgroundImage = listImage[index];
                    this.AnimationTimer.Tag = index + 1;
                };

                this.AnimationTimer.Start();
            }
            else
            {
                this.AnimationTimer.Stop();
            }
        }
        #endregion

        #region Instant Replication
        /// PERMET DE DETERMINER SI UN FICHIER A CHANGE
        private void LocalFileChanged(object sender, FileSystemEventArgs e)
        {
            if (!e.Name.ToLower().EndsWith(".tmp") && e.Name != "filesync.metadata")
            {
                // si sync auto lance une synchro
                if (((FormMain)this.MainForm).AutoSync)
                {
                    try
                    {
                        this.SyncHistory.Add(new KeyValuePair<DateTime, string>(DateTime.Now, string.Format("Replication instantanée: {0} de {1}", e.ChangeType.ToString(), e.Name)));
                        bool isDone = true;
                        switch (e.ChangeType)
                        {
                            //case WatcherChangeTypes.All:
                            //break;
                            case WatcherChangeTypes.Changed:
                                this.FileSync.CopyFile(e);
                                break;

                            case WatcherChangeTypes.Created:
                                this.FileSync.CopyFile(e);
                                break;

                            case WatcherChangeTypes.Deleted:
                                this.FileSync.DeleteFile(e);
                                break;

                            case WatcherChangeTypes.Renamed:
                                this.FileSync.RenameFile((RenamedEventArgs)e);
                                break;

                            default:
                                isDone = false;
                                break;
                        }

                        if (isDone)
                        {
                            this.labelSync.Invoke((MethodInvoker)(() =>
                            {
                                this.SyncHistory.Add(new KeyValuePair<DateTime, string>(DateTime.Now, string.Format("Replication instantanée terminée : {0}", e.Name)));
                                //this.buttonSync.Visible = true;
                                this.labelSync.ForeColor = Color.Orange;
                                this.labelSync.Text = "Replication instantanée effectuée !";
                            }));
                        }
                        else
                        {
                            this.labelSync.Invoke((MethodInvoker)(() =>
                            {
                                this.SyncHistory.Add(new KeyValuePair<DateTime, string>(DateTime.Now, string.Format("Replication instantanée échouée : {0}", e.Name)));
                                //this.buttonSync.Visible = true;
                                this.labelSync.ForeColor = Color.Red;
                                this.labelSync.Text = "Replication instantanée échouée!";
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        this.labelSync.Invoke((MethodInvoker)(() =>
                        {
                            this.SyncHistory.Add(new KeyValuePair<DateTime, string>(DateTime.Now, string.Format("Replication instantanée échouée : ", ex.Message)));
                            //this.buttonSync.Visible = true;
                            this.labelSync.ForeColor = Color.Red;
                            this.labelSync.Text = "Replication instantanée échouée!";
                        }));
                    }
                }
                else
                {
                    // Si pas de sync auto, change juste le label de synchro pour informer
                    if (!this.IsSyncInProgress)
                    {
                        this.labelSync.Invoke((MethodInvoker)(() =>
                        {
                            this.buttonSync.Visible = true;
                            this.labelSync.ForeColor = Color.Red;
                            this.labelSync.Text = "Fichiers non synchronisés!";
                        }));
                    }
                }

                // Attend 1 minutes avant de lancer une synchro
                //var syncTimer = new System.Timers.Timer();
                //syncTimer.Interval = 30000;
                //syncTimer.Elapsed += (t, args) =>
                //{
                //    if (!this.IsSyncInProgress)
                //    {
                //        this.StartSync();
                //    }

                //    syncTimer.Stop();
                //};

                //syncTimer.Start();
            }
        }

        private void StartWatchLocalFolder()
        {
            this.LocalFolderWatcher.EnableRaisingEvents = true;
        }

        private void StoptWatchLocalFolder()
        {
            this.LocalFolderWatcher.EnableRaisingEvents = false;
        }

        #endregion FileWatcher

        #region Utilities
        private NetworkConnection GetNetworkConnection(string uncPath)
        {
            var credentials = new NetworkCredential(this.SSHConnectionInfos.Username, this.ConnexionPassword);
            return new NetworkConnection(uncPath, credentials);
        }
        #endregion
    }
}