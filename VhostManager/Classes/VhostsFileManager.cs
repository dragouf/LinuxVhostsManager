using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VhostManager
{
    public class VhostsFileManager
    {
        public static void CreateVhost(VhostDetails vhost, ConnectionInfo sshInfos)
        {
            var cheminVhost = string.Format("/var/www/vhosts/{0}", vhost.Nom).Trim();

            using (var client = new SshClient(sshInfos))
            {
                client.Connect();

                // cree les dossiers
                client.RunCommand(string.Format("mkdir -p {0}/httpdocs", cheminVhost));
                client.RunCommand(string.Format("mkdir -p {0}/logs", cheminVhost));
                client.RunCommand(string.Format("mkdir -p {0}/conf", cheminVhost));

                // Cree les fichiers de log
                client.RunCommand(string.Format("touch {0}/logs/error.log", cheminVhost));
                client.RunCommand(string.Format("touch {0}/logs/access.log", cheminVhost));

                // donne les droits
                client.RunCommand(string.Format("chown -R $USER:$USER {0}", cheminVhost));
                client.RunCommand(string.Format("chmod -R 755 {0}", cheminVhost));

                // Cree le fichier contenant le chemin local
                client.RunCommand(string.Format(@"cat <<EOF >> {0}/conf/local
{1}
EOF", cheminVhost, vhost.CheminLocal).Replace("\r\n", "\n"));

                // Cree le fichier contenant la liste des sous domaine
                client.RunCommand(string.Format(@"cat <<EOF >> {0}/conf/sousdomaines
{1}
EOF", cheminVhost, vhost.SousDomaines.ToFlatString()).Replace("\r\n", "\n"));

                // Cree un fichier d'index
                client.RunCommand(string.Format(@"cat <<EOF >> {0}/httpdocs/index.html
Felicitation! Votre vhost est bien configure !<BR>
Vous pouvez maintenant lancer la synchronisation de vos fichiers a l'aide de 'vhosts manager'.<BR>
Si c'est deja fait il ne vous reste plus qu'a supprimer ce fichier (index.html).<BR><BR>
<b>Dragouf</b>
EOF", cheminVhost).Replace("\r\n", "\n"));

                // Cree une liste d'alias de sous domaine
                var serverAliases = vhost.SousDomaines.Select(s => string.Format("        ServerAlias {0}.{1}", s, vhost.Nom));

                // Cree le fichier vhost
                client.RunCommand(string.Format(@"cat <<EOF >> /etc/apache2/sites-available/{0}
<VirtualHost *:80>
        ServerAdmin webmaster@localhost
        ServerName {0}
        {2}
        DocumentRoot {1}/httpdocs
        <Directory {1}/httpdocs/>
                Options Indexes FollowSymLinks MultiViews
                AllowOverride All
                Order allow,deny
                allow from all
        </Directory>
        ErrorLog {1}/logs/error.log
        CustomLog {1}/logs/access.log combined
        RewriteLog {1}/logs/rewrite.log
        RewriteLogLevel 3
        php_flag log_errors on
        php_flag display_errors on
        php_value error_reporting 30719
</VirtualHost>
EOF", vhost.Nom, cheminVhost, serverAliases.ToFlatString()).Replace("\r\n", "\n"));

                // Declare le bhost
                client.RunCommand(string.Format("a2ensite {0}", vhost.Nom));

                // Recharge la config
                client.RunCommand(" service apache2 restart");

                client.Disconnect();
            }
        }

        public static string GetVhostsFolderSize(ConnectionInfo sshInfos)
        {
            string result = string.Empty;

            using (var client = new SshClient(sshInfos))
            {
                client.Connect();
                result = client.RunCommand("du -hs /var/www/vhosts/").Result.Replace("\n", "").Replace("/var/www/vhosts/","");
                client.Disconnect();
            }

            return result;
        }

        public static HddSpaceInfos GetDiskUsageInfo(ConnectionInfo sshInfos)
        {
            HddSpaceInfos result = new HddSpaceInfos();

            using (var client = new SshClient(sshInfos))
            {
                client.Connect();
                var reponse = client.RunCommand("df / |grep /dev/mapper/").Result.Replace("\n", "");

                try
                {
                    var elements = reponse.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    result.Total = Convert.ToInt32(elements[1]);
                    result.Used = Convert.ToInt32(elements[2]);
                }
                catch { }

                client.Disconnect();
            }

            return result;
        }

        public static string GetDiskSize(ConnectionInfo sshInfos)
        {
            string result = string.Empty;

            using (var client = new SshClient(sshInfos))
            {
                client.Connect();
                var reponse = client.RunCommand("df -h / |grep /dev/mapper/").Result.Replace("\n", "");

                try
                {
                    var elements = reponse.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    result = elements[1];
                    //result.Used = Convert.ToInt32(elements[2]);
                }
                catch { }

                client.Disconnect();
            }

            return result;
        }

        public static List<VhostDetails> ListVhosts(ConnectionInfo sshInfos)
        {
            var listeVhosts = new List<VhostDetails>();

            using (var client = new SshClient(sshInfos))
            {
                client.Connect();
                
                var resultat = client.RunCommand("ls -1 /etc/apache2/sites-available/");
                
                foreach (string vhostName in resultat.Result.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Where(v => !v.Contains("default")))
                {
                    var cheminLocal = client.RunCommand(string.Format("cat /var/www/vhosts/{0}/conf/local", vhostName)).Result.Replace("\n", "");
                    var sousDomaines = client.RunCommand(string.Format("cat /var/www/vhosts/{0}/conf/sousdomaines", vhostName)).Result
                        .Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                    
                    listeVhosts.Add(new VhostDetails { 
                        Nom = vhostName,
                        CheminLocal = cheminLocal,
                        SousDomaines = sousDomaines
                    });
                }

                client.Disconnect();
            }

            return listeVhosts;
        }

        public static void DeleteVhosts(string nomDomaine, ConnectionInfo sshInfos)
        {
            using (var client = new SshClient(sshInfos))
            {
                client.Connect();

                // stop les services
                client.RunCommand("service apache2 stop");

                // Supprimes les dossiers
                client.RunCommand(string.Format("rm -rf /var/www/vhosts/{0}/", nomDomaine));
                    client.RunCommand(string.Format("rm -f /etc/apache2/sites-enabled/{0}", nomDomaine));
                client.RunCommand(string.Format("rm -f /etc/apache2/sites-available/{0}", nomDomaine));

                // Redemarre les services
                client.RunCommand("service apache2 start");

                client.Disconnect();
            }
        }
    }
}
