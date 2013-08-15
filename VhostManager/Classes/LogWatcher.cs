using System;
using Renci.SshNet;

namespace VhostManager
{
    internal class LogWatcher : IDisposable
    {
        public LogWatcher(ConnectionInfo sshInfos, out bool isConnected)
        {
            this.SshInfos = sshInfos;
            isConnected = TryConnect();
        }

        private SshClient ClientConnection { get; set; }

        private ConnectionInfo SshInfos { get; set; }

        public void Dispose()
        {
            if (ClientConnection != null)
            {
                if (ClientConnection.IsConnected)
                    ClientConnection.Disconnect();
                ClientConnection.Dispose();
            }
        }

        public string GetGlobalErrorLog(int lineLimit)
        {
            string command = string.Format("tail -n {0} /var/log/apache2/error.log", lineLimit);
            var resultat = this.ClientConnection.RunCommand(command).Result;
            return resultat.Replace("\n", Environment.NewLine);
        }

        public string GetVhostAccessLog(string vhostName, int lineLimit)
        {
            string command = string.Format("tail -n {1} /var/www/vhosts/{0}/logs/access.log", vhostName, lineLimit);
            var resultat = this.ClientConnection.RunCommand(command).Result;
            return resultat.Replace("\n", Environment.NewLine);
        }

        public string GetVhostErrorLog(string vhostName, int lineLimit)
        {
            string command = string.Format("tail -n {1} /var/www/vhosts/{0}/logs/error.log", vhostName, lineLimit);
            var resultat = this.ClientConnection.RunCommand(command).Result;
            return resultat.Replace("\n", Environment.NewLine);
        }

        public string GetVhostRewriteLog(string vhostName, int lineLimit)
        {
            string command = string.Format("tail -n {1} /var/www/vhosts/{0}/logs/rewrite.log", vhostName, lineLimit);
            var resultat = this.ClientConnection.RunCommand(command).Result;
            return resultat.Replace("\n", Environment.NewLine);
        }

        public string GetLoadAverage()
        {
            string command = string.Format("cat /proc/loadavg");
            var resultat = this.ClientConnection.RunCommand(command).Result;
            return resultat.Substring(0, 15).Replace("\n", Environment.NewLine);
        }

        public double GetApacheCpuUsage()
        {
            double cpuUsage = 0;
            string command = string.Format("ps auxf |grep apache2 |grep -v grep");

            var resultat = this.ClientConnection.RunCommand(command)
                .Result.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var ligne in resultat)
            {
                var ligneDetails = ligne.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                cpuUsage += Convert.ToDouble(ligneDetails[2].Replace(".", ","));
            }

            return cpuUsage;
        }

        public double GetMySQLCpuUsage()
        {
            double cpuUsage = 0;
            string command = string.Format("ps auxf |grep mysqld |grep -v grep");

            var resultat = this.ClientConnection.RunCommand(command)
                .Result.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var ligne in resultat)
            {
                var ligneDetails = ligne.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                cpuUsage += Convert.ToDouble(ligneDetails[2].Replace(".", ","));
            }

            return cpuUsage;
        }

        public bool TryConnect()
        {
            bool isConnected = true;

            if (this.ClientConnection == null || !this.ClientConnection.IsConnected)
            {
                try
                {
                    this.ClientConnection = new SshClient(SshInfos);
                    this.ClientConnection.Connect();
                }
                catch
                {
                    isConnected = false;
                }
            }
            //else if (this.ClientConnection.IsConnected)
            //{
            //    this.ClientConnection.Disconnect();
            //    this.ClientConnection.Connect();
            //}

            return isConnected;
        }
    }
}