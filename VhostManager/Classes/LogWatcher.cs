using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VhostManager
{
    class LogWatcher : IDisposable
    {
        private SshClient ClientConnection { get; set; }
        public LogWatcher(ConnectionInfo sshInfos, out bool isConnected)
        {
            isConnected = true;

            try
            {
                this.ClientConnection = new SshClient(sshInfos);
                this.ClientConnection.Connect();
            }
            catch
            {
                isConnected = false;
            }
        }

        public string GetVhostErrorLog(string vhostName)
        {
            string command = string.Format("tail -n 2000 /var/www/vhosts/{0}/logs/error.log", vhostName);
            var resultat = this.ClientConnection.RunCommand(command).Result;
            return resultat.Replace("\n", Environment.NewLine);
        }

        public string GetVhostAccessLog(string vhostName)
        {
            string command = string.Format("tail -n 2000 /var/www/vhosts/{0}/logs/access.log", vhostName);
            var resultat = this.ClientConnection.RunCommand(command).Result;
            return resultat.Replace("\n", Environment.NewLine);
        }

        public string GetVhostRewriteLog(string vhostName)
        {
            string command = string.Format("tail -n 2000 /var/www/vhosts/{0}/logs/rewrite.log", vhostName);
            var resultat = this.ClientConnection.RunCommand(command).Result;
            return resultat.Replace("\n", Environment.NewLine);
        }

        public string GetGlobalErrorLog()
        {
            string command = "tail -n 2000 tail -n 2000 /var/log/apache2/error.log";
            var resultat = this.ClientConnection.RunCommand(command).Result;
            return resultat.Replace("\n", Environment.NewLine);
        }

        public void Dispose()
        {
            if (ClientConnection != null)
            {
                if (ClientConnection.IsConnected)
                    ClientConnection.Disconnect();
                ClientConnection.Dispose();
            }
        }
    }
}
