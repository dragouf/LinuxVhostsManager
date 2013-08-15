using System.Drawing;
using Renci.SshNet;
using System;
using System.ComponentModel;
using System.Text;
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

            InitOnResize();            

            if (isConnected)
            {
                this.timerRefresh.Start();
            }
        }

        private void InitOnResize()
        {            
            this.ResizeBegin += (s, e) => {
                this.SuspendLayout();
            };
            this.ResizeEnd += (s, e) => { 
                this.ResumeLayout(true);
            };
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
            string newErrorLog = null;
            string newAccessLog = null;
            string newRewriteLog = null;
            string newGlobalErrorLog = null;

            string loadAverage = null;
            double mysqlCpu = 0;
            double apacheCpu = 0;

            const string message = "Les mises a jour ne se font plus.\r\n Tentez de fermer la fenetre et de la reouvrir pour relancer le rafraichissement.";

            bool isOK = true;
            this.IsRefreshing = true;

            var bw = new BackgroundWorker();
            // DEMARRE
            bw.DoWork += (s, args) =>
            {
                try
                {
                    newErrorLog = this.Watcher.GetVhostErrorLog(this.VhostName, lineLimit: 1000);
                    newAccessLog = this.Watcher.GetVhostAccessLog(this.VhostName, lineLimit: 1000);
                    newRewriteLog = this.Watcher.GetVhostRewriteLog(this.VhostName, lineLimit: 1000);
                    newGlobalErrorLog = this.Watcher.GetGlobalErrorLog(lineLimit: 1000);

                    loadAverage = this.Watcher.GetLoadAverage();
                    mysqlCpu = this.Watcher.GetMySQLCpuUsage();
                    apacheCpu = this.Watcher.GetApacheCpuUsage();
                }
                catch
                {
                    if (!this.Watcher.TryConnect())
                    {
                        isOK = false;
                        this.timerRefresh.Stop();
                        MessageBox.Show(this, message, "Erreur de connexion SSH", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        isOK = false;
                    }
                }
            };

            // TERMINE
            bw.RunWorkerCompleted += (s, args) =>
            {
                if (isOK)
                {
                    try
                    {
                        this.textBoxError.Text = newErrorLog;
                        this.textBoxAcces.Text = newAccessLog;
                        this.textBoxRewriteLogs.Text = newRewriteLog;
                        this.textBoxErrorGlobal.Text = newGlobalErrorLog;

                        ScrollDownTextBox(this.textBoxError);
                        ScrollDownTextBox(this.textBoxAcces);
                        ScrollDownTextBox(this.textBoxRewriteLogs);
                        ScrollDownTextBox(this.textBoxErrorGlobal);

                        var loads = loadAverage.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                        labelLoad1.Text = loads[0];
                        labelLoad2.Text = loads[1];
                        labelLoad3.Text = loads[2];
                        labelApachePourcent.Text = string.Format("{0} %", apacheCpu.ToString("F2"));
                        labelMysqlPourcent.Text = string.Format("{0} %", mysqlCpu.ToString("F2")); 
                        colorProgressBarApache.BrushColor = apacheCpu < 85 ? Brushes.Green : Brushes.Red;
                        colorProgressBarMysql.BrushColor = mysqlCpu < 85 ? Brushes.Green : Brushes.Red;
                        colorProgressBarApache.Value = apacheCpu > 100 ? 100 : (int)apacheCpu;
                        colorProgressBarMysql.Value = mysqlCpu > 100 ? 100 : (int)mysqlCpu;
                    }
                    catch
                    {
                        newErrorLog = null;
                        newAccessLog = null;
                        newRewriteLog = null;
                        newGlobalErrorLog = null;

                        this.textBoxError.Text = null;
                        this.textBoxAcces.Text = null;
                        this.textBoxRewriteLogs.Text = null;
                        this.textBoxErrorGlobal.Text = null;

                        // Try clean
                        System.GC.Collect(0, GCCollectionMode.Forced, true);

                        isOK = false;
                    }
                }

                if(!isOK)
                    labelUpdateError.Text = "Erreur de conexion...";
                else
                    labelUpdateError.Text = string.Empty;

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