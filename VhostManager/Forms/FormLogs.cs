using Renci.SshNet;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace VhostManager
{
    public partial class FormLogs : Form
    {
        public FormLogs(string nomVhost, ConnectionInfo sshInfos)
        {
            InitializeComponent();
            this.Text = nomVhost + this.Text;

            this.IsRefreshing = false;            
            this.VhostName = nomVhost;
            bool isConnected = false;
            this.Watcher = new LogWatcher(sshInfos, out isConnected);
            
            if (isConnected)
            {
                this.timerRefresh.Start();
            }
        }

        #region Properties
        public bool IsRefreshing { get; set; }

        public string VhostName { get; set; }

        private LogWatcher Watcher { get; set; }
        #endregion


        private void FormLogs_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Watcher.Dispose();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (!IsRefreshing)
            {
                RefreshLogsContentAsync();
            }
        }


        private void RefreshLogsContentAsync()
        {
            string newErrorLog = string.Empty;
            string newAccessLog = string.Empty;
            string newRewriteLog = string.Empty;
            string newGlobalErrorLog = string.Empty;

            bool isOK = true;
            this.IsRefreshing = true;

            var bw = new BackgroundWorker();
            // DEMARRE
            bw.DoWork += (s, args) =>
            {
                try
                {
                    newErrorLog = this.Watcher.GetVhostErrorLog(this.VhostName);
                    newAccessLog = this.Watcher.GetVhostAccessLog(this.VhostName);
                    newRewriteLog = this.Watcher.GetVhostRewriteLog(this.VhostName);
                    newGlobalErrorLog = this.Watcher.GetGlobalErrorLog();
                }
                catch
                {
                    if (!this.Watcher.TryConnect())
                    {
                        isOK = false;
                        this.timerRefresh.Stop();
                        MessageBox.Show(this, "Les mises a jour ne se font plus.\r\n Tentez de fermer la fenetre et de la reouvrir pour relancer le rafraichissement.", "Erreur de connexion SSH", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            };

            // TERMINE
            bw.RunWorkerCompleted += (s, args) =>
            {
                if (isOK)
                {
                    string oldErrorLog = this.textBoxError.Text;
                    if (newErrorLog != oldErrorLog)
                    {
                        this.textBoxError.Text = newErrorLog;
                        ScrollDownTextBox(this.textBoxError);
                    }

                    string oldAccessLog = this.textBoxAcces.Text;
                    if (newAccessLog != oldAccessLog)
                    {
                        this.textBoxAcces.Text = newAccessLog;
                        ScrollDownTextBox(this.textBoxAcces);
                    }

                    string oldRewriteLog = this.textBoxRewriteLogs.Text;
                    if (newRewriteLog != oldRewriteLog)
                    {
                        this.textBoxRewriteLogs.Text = newRewriteLog;
                        ScrollDownTextBox(this.textBoxRewriteLogs);
                    }

                    string oldGlobalAccessLog = this.textBoxErrorGlobal.Text;
                    if (newGlobalErrorLog != oldGlobalAccessLog)
                    {
                        this.textBoxErrorGlobal.Text = newGlobalErrorLog;
                        ScrollDownTextBox(this.textBoxErrorGlobal);
                    }
                }

                this.IsRefreshing = false;
            };

            // LANCE
            bw.RunWorkerAsync();
        }


        private void ScrollDownTextBox(TextBox box)
        {
            box.Select(box.Text.Length, 0);
            box.ScrollToCaret();
        }
    }
}