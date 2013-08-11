using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VhostManager
{
    public static class HostsFileManager
    {
        private static string HostFile = @"C:\Windows\System32\Drivers\etc\hosts";

        public static bool IsHostNameExist(string hostname)
        {
            bool exist = false;

            int counter = 0;
            string line;

            // Read the file and display it line by line.
            var file = new StreamReader(HostFile);
            while ((line = file.ReadLine()) != null)
            {
                if (!line.StartsWith("#") && line.Contains(hostname))
                {
                    exist = true;
                }
                counter++;
            }

            file.Close();

            return exist;
        }

        public static void DeleteHostName(string hostname)
        {
            string line = null;
            string newFileContent = string.Empty;

            using (StreamReader reader = new StreamReader(HostFile))
            {

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(hostname))
                        continue;
                    newFileContent += line + Environment.NewLine;
                }
            }


            using (StreamWriter writer = new StreamWriter(HostFile))
            {
                writer.Write(newFileContent);
            }
        }

        public static void AddHostName(string hostname, List<string> sousDomaines, string ip)
        {
            DeleteHostName(hostname);

            File.AppendAllText(HostFile, Environment.NewLine);
            File.AppendAllText(HostFile, string.Format("{0} {1}{2}", ip, hostname, Environment.NewLine));
            foreach (var sub in sousDomaines)
            {
                File.AppendAllText(HostFile, string.Format("{0} {2}.{1}{3}", ip, hostname, sub, Environment.NewLine));
            }
            
        }
    }
}
