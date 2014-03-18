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
        private StringBuilder NewErrorLog;
        private StringBuilder NewAccessLog;
        private StringBuilder NewRewriteLog;
        private StringBuilder NewGlobalErrorLog;
        private StringBuilder LoadAverage;

        public FormLogs(string nomVhost, ConnectionInfo sshInfos)
        {
            InitializeComponent();

            this.NewErrorLog = new StringBuilder();
            this.NewAccessLog = new StringBuilder();
            this.NewRewriteLog = new StringBuilder();
            this.NewGlobalErrorLog = new StringBuilder();
            this.LoadAverage = new StringBuilder();
            
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

            this.NewErrorLog.Clear();
            this.NewAccessLog.Clear();
            this.NewRewriteLog.Clear();
            this.NewGlobalErrorLog.Clear();
            this.LoadAverage.Clear();
            
            this.textBoxAcces.Dispose();
            this.textBoxError.Dispose();
            this.textBoxErrorGlobal.Dispose();
            this.textBoxRewriteLogs.Dispose();
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
                    this.NewErrorLog.Clear();
                    this.NewAccessLog.Clear();
                    this.NewRewriteLog.Clear();
                    this.NewGlobalErrorLog.Clear();
                    this.LoadAverage.Clear();

                    NewErrorLog.Append(this.Watcher.GetVhostErrorLog(this.VhostName, lineLimit: 1000));
                    NewAccessLog.Append(this.Watcher.GetVhostAccessLog(this.VhostName, lineLimit: 1000));
                    NewRewriteLog.Append(this.Watcher.GetVhostRewriteLog(this.VhostName, lineLimit: 1000));
                    NewGlobalErrorLog.Append(this.Watcher.GetGlobalErrorLog(lineLimit: 1000));

                    LoadAverage.Append(this.Watcher.GetLoadAverage());
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
                        if (!NewErrorLog.ToString().Equals(this.textBoxError.Text))
                        {
                            this.textBoxError.Text = NewErrorLog.ToString();
                            ScrollDownTextBox(this.textBoxError);
                        }

                        if (!NewAccessLog.ToString().Equals(this.textBoxAcces.Text))
                        {
                            this.textBoxAcces.Text = NewAccessLog.ToString();
                            ScrollDownTextBox(this.textBoxAcces);
                        }

                        if (!NewRewriteLog.ToString().Equals(this.textBoxRewriteLogs.Text))
                        {
                            this.textBoxRewriteLogs.Text = NewRewriteLog.ToString();
                            ScrollDownTextBox(this.textBoxRewriteLogs);
                        }

                        if (!NewGlobalErrorLog.Equals(this.textBoxErrorGlobal.Text))
                        {
                            this.textBoxErrorGlobal.Text = NewGlobalErrorLog.ToString();
                            ScrollDownTextBox(this.textBoxErrorGlobal);
                        }

                        var loads = LoadAverage.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
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
                        isOK = false;
                    }
                }

                if (!isOK)
                {
                    NewErrorLog = null;
                    NewAccessLog = null;
                    NewRewriteLog = null;
                    NewGlobalErrorLog = null;

                    this.textBoxError.Text = null;
                    this.textBoxAcces.Text = null;
                    this.textBoxRewriteLogs.Text = null;
                    this.textBoxErrorGlobal.Text = null;

                    // Try clean
                    System.GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);

                    labelUpdateError.Text = "Erreur de conexion...";
                }
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