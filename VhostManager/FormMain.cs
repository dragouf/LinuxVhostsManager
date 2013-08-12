using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VhostManager
{
    public partial class FormMain : Form
    {
        private ColorProgressBar progressBarFreeSpace;

        public SyncDirection SyncDirection
        {
            get
            {
                if (this.radioButtonUpload.Checked)
                {
                    return SyncDirection.Upload;
                }
                else if (this.radioButtonDownload.Checked)
                {
                    return SyncDirection.Download;
                }
                else
                {
                    return SyncDirection.Both;
                }
            }
        }
        public bool AutoSync
        {
            get
            {
                return this.radioButtonSyncOui.Checked;
            }
        }
        public ToolStripStatusLabel StatusBarLabel { get { return this.toolStripStatusLabelEtat; } }

        private ConnectionInfo SSHConnectionInfos
        {
            get
            {
                var authMethod = new PasswordAuthenticationMethod(this.textBoxUser.Text, this.textBoxPassword.Text);
                return new ConnectionInfo(this.textBoxHost.Text, (int)this.numericUpDownPort.Value, this.textBoxUser.Text, authMethod);
            }
        }

        public FormMain()
        {
            InitializeComponent();
            // free disk space linux 
            this.progressBarFreeSpace = new ColorProgressBar();
            this.progressBarFreeSpace.Location = new System.Drawing.Point(140, 25);
            this.progressBarFreeSpace.Name = "progressBarFreeSpace";
            this.progressBarFreeSpace.Size = new System.Drawing.Size(228, 13);
            this.progressBarFreeSpace.TabIndex = 13;
            this.groupBox1.Controls.Add(this.progressBarFreeSpace);

            this.LoadSettings();
            this.LoadSshInfosAsync();
        }

        private void LoadSshInfosAsync()
        {
            bool isConnected = false;
            string messageErreur = string.Empty;
            var listeVhosts = new List<VhostDetails>();
            string tailleVhosts = string.Empty;
            var hddInfos = new HddSpaceInfos();

            toolStripStatusLabelEtat.ForeColor = Color.Orange;
            toolStripStatusLabelEtat.Text = "Collecte des données distantes en cours...";

            var bw = new BackgroundWorker();
            bw.DoWork += (sender, args) =>
            {
                try
                {
                    listeVhosts = this.EnumerateVhosts();
                    isConnected = true;

                    // C'est un plus et on se moque si ca bug...
                    try
                    {
                        tailleVhosts = VhostsFileManager.GetVhostsFolderSize(this.SSHConnectionInfos);
                        hddInfos = VhostsFileManager.GetDiskUsageInfo(this.SSHConnectionInfos);
                    }
                    catch { }
                }
                catch (Exception ex)
                {
                    isConnected = false;
                    messageErreur = ex.Message;
                }
            };

            bw.RunWorkerCompleted += (sender, args) =>
            {
                if (isConnected)
                {
                    this.LoadVhostsTabs(listeVhosts);

                    // Affiche les donnees linux
                    this.labelTailleVhosts.Text = tailleVhosts;
                    this.progressBarFreeSpace.Maximum = hddInfos.Total;
                    this.progressBarFreeSpace.Value = hddInfos.Used;
                    this.progressBarFreeSpace.BrushColor = (hddInfos.Used * 100 / hddInfos.Total) < 85 ? Brushes.Green : Brushes.Red;

                    //Affichage temporaire d'un message de succes 
                    toolStripStatusLabelEtat.ForeColor = Color.Green;
                    toolStripStatusLabelEtat.Text = "Connexion terminée";
                    //Timer t = new Timer();
                    //t.Interval = 1000;
                    //t.Tick += (o, a) =>
                    //{
                    //    t.Stop();
                    //    toolStripStatusLabelEtat.ForeColor = Color.Black;
                    //    toolStripStatusLabelEtat.Text = string.Empty;
                    //};
                    //t.Start();
                }
                else
                {
                    toolStripStatusLabelEtat.ForeColor = Color.Red;
                    toolStripStatusLabelEtat.Text = string.Format("Connection échouée ({0})", messageErreur);
                }
            };

            bw.RunWorkerAsync();
        }

        private void LoadVhostsTabs(List<VhostDetails> liste)
        {
            // Recree les onglets
            foreach (var vhost in liste)
            {
                // Ajoute que si n'existe pas deja
                if (!this.IsTabContainVhost(vhost.Nom))
                {
                    var tab = new TabPage(vhost.Nom);
                    tab.Tag = vhost;

                    var vhostTab = new VhostTab(vhost, this.SSHConnectionInfos, this.textBoxPassword.Text, parentForm: this);
                    vhostTab.Dock = DockStyle.Fill;
                    vhostTab.VhostDeleted += () => { this.LoadSshInfosAsync(); };
                    tab.Controls.Add(vhostTab);

                    this.tabControlMain.TabPages.Add(tab);
                }
            }

            // Retire les tab qui ne sont plus dans la liste
            var vhostTabs = new List<TabPage>();
            foreach (TabPage tab in this.tabControlMain.TabPages)
            {
                if (tab.Tag is VhostDetails)
                {
                    if (!liste.Select(v => v.Nom).Contains(((VhostDetails)tab.Tag).Nom))
                    {
                        vhostTabs.Add(tab);
                    }
                }
            }

            foreach (var tab in vhostTabs)
            {
                this.tabControlMain.TabPages.Remove(tab);
            }
            vhostTabs.Clear();
        }

        private bool IsTabContainVhost(string domainName)
        {
            foreach (TabPage tab in this.tabControlMain.TabPages)
            {
                if (tab.Tag is VhostDetails)
                    if (((VhostDetails)tab.Tag).Nom == domainName)
                        return true;
            }

            return false;
        }

        private void buttonBrowseLocal_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialogLocal.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxCheminLocal.Text = this.folderBrowserDialogLocal.SelectedPath;
            }
        }

        private void textBoxNomDomaine_TextChanged(object sender, EventArgs e)
        {
            this.labelCheminDistant.Text = string.Format("/var/www/vhosts/{0}", this.textBoxNomDomaine.Text);
        }

        private void buttonCreerVhost_Click(object sender, EventArgs e)
        {
            string vhostUsedName = string.Empty;
            bool isVhostExist = false;
            bool isFolderUsed = false;
            bool IsFolderValid = Directory.Exists(this.textBoxCheminLocal.Text);

            foreach (TabPage tab in this.tabControlMain.TabPages)
            {
                if (tab.Tag is VhostDetails)
                {
                    var vhostDetails = (VhostDetails)tab.Tag;
                    if (vhostDetails.Nom == this.textBoxNomDomaine.Text)
                        isVhostExist = true;
                    if (vhostDetails.CheminLocal == this.textBoxCheminLocal.Text)
                    {
                        vhostUsedName = vhostDetails.Nom;
                        isFolderUsed = true;
                    }
                }
            }
            if (!isVhostExist && !isFolderUsed && IsFolderValid)
            {
                bool isOK = true;
                string errorMessage = string.Empty;

                string nomDomaine = this.textBoxNomDomaine.Text.Trim();               
                string cheminLocal = this.textBoxCheminLocal.Text.Trim();
                var sousDomaines = new List<string>();
                foreach (string item in this.comboBoxSousDomaine.Items)
                {
                    sousDomaines.Add(item.Trim());
                }

                var vhostDetails = new VhostDetails { CheminLocal = cheminLocal, Nom = nomDomaine, SousDomaines = sousDomaines };

                toolStripStatusLabelEtat.ForeColor = Color.Orange;
                toolStripStatusLabelEtat.Text = "Creation du vhost en cours...";
                this.textBoxNomDomaine.Text = string.Empty;
                this.textBoxCheminLocal.Text = string.Empty;

                buttonCreerVhost.Enabled = false;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, args) =>
                {
                    try
                    {
                        VhostsFileManager.CreateVhost(vhostDetails, this.SSHConnectionInfos);
                    }
                    catch (Exception ex)
                    {
                        isOK = false;
                        errorMessage = ex.Message;
                    }
                };
                bw.RunWorkerCompleted += (s, args) =>
                {
                    if (isOK)
                    {
                        toolStripStatusLabelEtat.ForeColor = Color.Green;
                        toolStripStatusLabelEtat.Text = "Création du vhost terminé...";
                        this.LoadSshInfosAsync();
                        // Affichage temporaire d'un message de succes                    
                        //Timer t = new Timer();
                        //t.Interval = 1000;
                        //t.Tick += (o, a) => {
                        //    t.Stop();
                        //    labelLoading.Text = string.Empty;
                        //};
                        //t.Start();
                    }
                    else
                    {
                        toolStripStatusLabelEtat.ForeColor = Color.Red;
                        toolStripStatusLabelEtat.Text = string.Format("Erreur lors de la creation du vhost : {0}", errorMessage);
                    }

                    buttonCreerVhost.Enabled = true;
                };

                bw.RunWorkerAsync();
            }
            else
            {
                string message = string.Empty;

                if (isFolderUsed)
                    message = string.Format("Ce dossier local est déja utilié pour le vhost {0}.", vhostUsedName) + Environment.NewLine;
                if (isVhostExist)
                    message += "Ce vhost est déja présent sur le serveur." + Environment.NewLine;
                if (!IsFolderValid)
                    message += "Le dossier local n'est pas valide.";

                MessageBox.Show(message, "Données existante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private List<VhostDetails> EnumerateVhosts()
        {
            return VhostsFileManager.ListVhosts(this.SSHConnectionInfos);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Enregistre les parametres ssh
            this.SaveSettings();
        }

        #region Parametres
        private void LoadSettings()
        {
            Properties.Settings.Default.Upgrade();

            this.textBoxHost.Text = Properties.Settings.Default.SshHost;
            this.numericUpDownPort.Value = Properties.Settings.Default.SshPort;
            this.textBoxUser.Text = Properties.Settings.Default.SshUser;
            this.textBoxPassword.Text = SecurePassword.ToInsecureString(SecurePassword.DecryptString(Properties.Settings.Default.SshPassword));
            this.radioButtonSyncOui.Checked = Properties.Settings.Default.AutoSync;
            this.radioButtonSyncNon.Checked = !Properties.Settings.Default.AutoSync;

            switch (Properties.Settings.Default.SyncDirection.ToEnum<SyncDirection>())
            {
                case SyncDirection.Upload: this.radioButtonUpload.Checked = true;
                    break;
                case SyncDirection.Download: this.radioButtonDownload.Checked = true;
                    break;
                case SyncDirection.Both: this.radioButtonBoth.Checked = true;
                    break;
                default: this.radioButtonUpload.Checked = true;
                    break;
            }
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.SshHost = this.textBoxHost.Text;
            Properties.Settings.Default.SshPort = (int)this.numericUpDownPort.Value;
            Properties.Settings.Default.SshUser = this.textBoxUser.Text;
            Properties.Settings.Default.SshPassword = SecurePassword.EncryptString(SecurePassword.ToSecureString(this.textBoxPassword.Text));
            Properties.Settings.Default.SyncDirection = (int)this.SyncDirection;
            Properties.Settings.Default.AutoSync = this.AutoSync;

            Properties.Settings.Default.Save();
        }
        #endregion

        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            this.SaveSettings();
            this.LoadSshInfosAsync();
        }

        private void buttonAddSubDomain_Click(object sender, EventArgs e)
        {
            this.comboBoxSousDomaine.Items.Add(this.comboBoxSousDomaine.Text);
            this.comboBoxSousDomaine.Text = string.Empty;
        }

        private void comboBoxSousDomaine_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete)
            {
                if (comboBoxSousDomaine.SelectedIndex >= 0 && comboBoxSousDomaine.Items.Count > 1)
                    comboBoxSousDomaine.Items.RemoveAt(comboBoxSousDomaine.SelectedIndex);
            }
        }
    }
}
