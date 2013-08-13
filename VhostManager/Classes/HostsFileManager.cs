using System;
using System.Collections.Generic;
using System.IO;

namespace VhostManager
{
    public static class HostsFileManager
    {
        private static string HostFile = @"C:\Windows\System32\Drivers\etc\hosts";

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

        public static bool HasAcces()
        {
            bool isOk = true;
            try
            {
                File.AppendAllText(HostFile, Environment.NewLine);
            }
            catch
            {
                isOk = false;
            }

            if (isOk)
                RemoveNewLineAtEnd();

            return isOk;
        }

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

        private static void RemoveNewLineAtEnd()
        {
            var contenu = File.ReadAllText(HostFile);
            contenu = contenu.TrimEnd('\r', '\n');
            File.WriteAllText(HostFile, contenu);
        }
    }
}