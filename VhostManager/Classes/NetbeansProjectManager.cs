using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VhostManager
{
    public static class NetbeansProjectManager
    {
        public static bool IsProjectExist(string localPath)
        {
            return File.Exists(string.Format(@"{0}\nbproject\project.xml", localPath));
        }

        public static void CreateProject(string localPath, string domainName)
        {
            var projectXmlFile = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\nbproject\\project.xml";
            var projectPropertiesFile = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\nbproject\\project.properties";
            var privatePropertiesFile = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\nbproject\\private.properties";
            var privateXmlFile = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\nbproject\\private.xml";

            var projectXmlContent = File.ReadAllText(projectXmlFile);
            projectXmlContent = string.Format(projectXmlContent, domainName);
            File.WriteAllText(projectXmlFile, projectXmlContent);
         
            var privatePropertiesContent = File.ReadAllText(privatePropertiesFile);
            privatePropertiesContent = string.Format(privatePropertiesContent, "www." + domainName);
            File.WriteAllText(privatePropertiesFile, privatePropertiesContent);

            // cree les dossiers
            string nbprojectFolder = string.Format(@"{0}\nbproject", localPath);
            string nbprojectPrivateFolder = string.Format(@"{0}\nbproject\private", localPath);
            if (!Directory.Exists(nbprojectFolder))
                Directory.CreateDirectory(nbprojectFolder);
            if (!Directory.Exists(nbprojectPrivateFolder))
                Directory.CreateDirectory(nbprojectPrivateFolder);

            // Copie les fichiers
            File.Copy(projectXmlFile, nbprojectFolder + "\\project.xml");
            File.Copy(projectPropertiesFile, nbprojectFolder + "\\project.properties");
            File.Copy(privatePropertiesFile, nbprojectFolder + "\\private\\private.properties");
            File.Copy(privateXmlFile, nbprojectFolder + "\\private\\private.xml");
        }
    }
}
