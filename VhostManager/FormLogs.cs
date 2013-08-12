using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VhostManager
{
    public partial class FormLogs : Form
    {
        private LogWatcher Watcher { get; set; }
        public string VhostName { get; set; }

        public FormLogs(string nomVhost, ConnectionInfo sshInfos)
        {
            InitializeComponent();
            this.Text = this.Text + nomVhost;
            this.VhostName = nomVhost;
            bool isConnected = false;
            this.Watcher = new LogWatcher(sshInfos, out isConnected);
            if (isConnected)
                this.timerRefresh.Enabled = true;
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            string newErrorLog = string.Empty;
            string newAccessLog = string.Empty;
            string newRewriteLog = string.Empty;
            string newGlobalErrorLog = string.Empty;

            var bw = new BackgroundWorker();
            // DEMARRE
            bw.DoWork += (s, args) =>
            {
                newErrorLog = this.Watcher.GetVhostErrorLog(this.VhostName);
                newAccessLog = this.Watcher.GetVhostAccessLog(this.VhostName);
                newRewriteLog = this.Watcher.GetVhostRewriteLog(this.VhostName);
                newGlobalErrorLog = this.Watcher.GetGlobalErrorLog();
            };

            // TERMINE
            bw.RunWorkerCompleted += (s, args) =>
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
            };

            // LANCE
            bw.RunWorkerAsync();
        }

        private void FormLogs_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Watcher.Dispose();
        }

        private void ScrollDownTextBox(TextBox box)
        {
            box.Select(box.Text.Length, 0);
            box.ScrollToCaret();
        }
    }
}
