using Renci.SshNet;
using System;

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

        public string GetGlobalErrorLog()
        {
            string command = "tail -n 2000 tail -n 2000 /var/log/apache2/error.log";
            var resultat = this.ClientConnection.RunCommand(command).Result;
            return resultat.Replace("\n", Environment.NewLine);
        }

        public string GetVhostAccessLog(string vhostName)
        {
            string command = string.Format("tail -n 2000 /var/www/vhosts/{0}/logs/access.log", vhostName);
            var resultat = this.ClientConnection.RunCommand(command).Result;
            return resultat.Replace("\n", Environment.NewLine);
        }

        public string GetVhostErrorLog(string vhostName)
        {
            string command = string.Format("tail -n 2000 /var/www/vhosts/{0}/logs/error.log", vhostName);
            var resultat = this.ClientConnection.RunCommand(command).Result;
            return resultat.Replace("\n", Environment.NewLine);
        }

        public string GetVhostRewriteLog(string vhostName)
        {
            string command = string.Format("tail -n 2000 /var/www/vhosts/{0}/logs/rewrite.log", vhostName);
            var resultat = this.ClientConnection.RunCommand(command).Result;
            return resultat.Replace("\n", Environment.NewLine);
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
            else if (this.ClientConnection.IsConnected)
            {
                this.ClientConnection.Disconnect();
                this.ClientConnection.Connect();
            }

            return isConnected;
        }
    }
}