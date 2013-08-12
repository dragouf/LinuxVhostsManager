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
            var projectXmlFile = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\nbproject\\project.new";
            var projectXmlFileGood = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\nbproject\\project.xml";
            var projectPropertiesFile = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\nbproject\\project.properties.new";
            var privatePropertiesFile = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\nbproject\\private.properties.new";
            var privatePropertiesFileGood = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\nbproject\\private.properties.new";
            var privateXmlFile = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\nbproject\\private.new";

            var projectXmlContent = File.ReadAllText(projectXmlFile);
            projectXmlContent = string.Format(projectXmlContent, domainName);
            File.WriteAllText(projectXmlFileGood, projectXmlContent);
         
            var privatePropertiesContent = File.ReadAllText(privatePropertiesFile);
            privatePropertiesContent = string.Format(privatePropertiesContent, "www." + domainName);
            File.WriteAllText(privatePropertiesFileGood, privatePropertiesContent);

            // cree les dossiers
            string nbprojectFolder = string.Format(@"{0}\nbproject", localPath);
            string nbprojectPrivateFolder = string.Format(@"{0}\nbproject\private", localPath);
            if (!Directory.Exists(nbprojectFolder))
                Directory.CreateDirectory(nbprojectFolder);
            if (!Directory.Exists(nbprojectPrivateFolder))
                Directory.CreateDirectory(nbprojectPrivateFolder);

            // Copie les fichiers
            File.Copy(projectXmlFileGood, nbprojectFolder + "\\project.xml");
            File.Copy(projectPropertiesFile, nbprojectFolder + "\\project.properties");
            File.Copy(privatePropertiesFileGood, nbprojectFolder + "\\private\\private.properties");
            File.Copy(privateXmlFile, nbprojectFolder + "\\private\\private.xml");
        }
    }
}
