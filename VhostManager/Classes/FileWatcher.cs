using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Resources;
using System.Reflection;
using System.Web;
using System.IO;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Timers;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Linq;

namespace VhostManager
{
    public class FileWatcher
    {
        private string UncPassword { get; set; }
        private string UncUsername { get; set; }
        private string UncPath { get; set; }
        private string LocalPath { get; set; }

        #region Getions DEPLACEMENT
        private string TempsDeleteUncFolder { get { return UncPath + "\\..\\.deleted"; } }
        private string NameOfPreviousDeletedFile { get; set; }
        private string NameOfPreviousCreatedFile { get; set; }
        #endregion

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool SetFileTime(IntPtr hFile, ref long lpCreationTime, ref long lpLastAccessTime, ref long lpLastWriteTime);
        //private const Int64 fileTimeUnchanged = 0xFFFFFFFF;

        public FileWatcher(string localPath, string uncPath, string uncUsername, string uncPassword)
        {
            this.LocalPath = localPath;
            this.UncPath = uncPath;
            this.UncUsername = uncUsername;
            this.UncPassword = uncPassword;
        }

        /// <summary>
        /// Connect to a network share with specific login
        /// </summary>
        /// <param name="uncPath"></param>
        /// <returns></returns>
        private NetworkConnection GetNetworkConnection()
        {
            var credentials = new NetworkCredential(this.UncUsername, this.UncPassword);
            return new NetworkConnection(this.UncPath, credentials);
        }

        public void CopyFile(System.IO.FileSystemEventArgs e)
        {
            using (this.GetNetworkConnection())
            {
                string source = e.FullPath;
                bool isfolder = System.IO.Directory.Exists(source);
                string dest = source.Replace(this.LocalPath, this.UncPath);

                if (isfolder)
                {
                    if (e.ChangeType == WatcherChangeTypes.Changed)
                    {
                        if (!string.IsNullOrEmpty(this.NameOfPreviousDeletedFile))
                        {
                            // Il s'agit d'un deplacement precedent (ancien fichier supprimé)
                            File.Move(this.TempsDeleteUncFolder + "\\" + this.NameOfPreviousDeletedFile, dest + "\\" + this.NameOfPreviousDeletedFile);                            
                        }
                        else if (!string.IsNullOrEmpty(this.NameOfPreviousCreatedFile))
                        {
                            // Il s'agit d'un deplacement precendent (Nouveau fichier créé)
                            File.Delete(dest + "\\" + this.NameOfPreviousCreatedFile);
                        }
                        else 
                        {
                            // des fichiers ont ete supprimés
                            var filesToDelete = FolderCompareForDeletedFiles(source, dest);
                            foreach (var file in filesToDelete)
                            {
                                File.Delete(file);
                            }

                            var dirToDelete = FolderCompareForDeletedFolders(source, dest);
                            foreach (var dir in dirToDelete)
                            {
                                Directory.Delete(dir);
                            }
                        }

                        this.ClearTempData();
                    }

                    Directory.CreateDirectory(dest);
                    CopyRecursivelyFolderToDestination(source, dest);
                }
                else
                {
                    this.NameOfPreviousCreatedFile = e.Name;
                    File.Copy(source, dest, true);
                }
            }
        }

        public void RenameFile(System.IO.RenamedEventArgs e)
        {
            using (this.GetNetworkConnection())
            {
                string source = e.OldFullPath.Replace(this.LocalPath, this.UncPath);
                string dest = e.FullPath.Replace(this.LocalPath, this.UncPath);
                bool isFolder = System.IO.Directory.Exists(source);
                if (isFolder)
                {
                    Directory.Move(source, dest);
                }
                else
                {
                    File.Move(source, dest);
                }
            }
        }

        public void DeleteFile(System.IO.FileSystemEventArgs e)
        {
            using (this.GetNetworkConnection())
            {
                string dest = e.FullPath.Replace(this.LocalPath, this.UncPath);
                bool isFolder = System.IO.Directory.Exists(dest);
                if (isFolder)
                {
                    Directory.Delete(dest, true);
                }
                else
                {
                    // Backup in temp folder in case it's move action
                    if (!Directory.Exists(TempsDeleteUncFolder))
                        Directory.CreateDirectory(TempsDeleteUncFolder);
                    this.NameOfPreviousDeletedFile = e.Name;
                    File.Move(dest, this.TempsDeleteUncFolder + "\\" + this.NameOfPreviousDeletedFile); 
                    //File.Delete(dest);
                }
            }
        }

        private void ClearTempData()
        {
            if (!Directory.Exists(TempsDeleteUncFolder))
                Directory.Delete(this.TempsDeleteUncFolder, true);
            this.NameOfPreviousDeletedFile = string.Empty;
            this.NameOfPreviousCreatedFile = string.Empty;
        }

        private void CopyRecursivelyFolderToDestination(string folder, string dest)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(folder, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(folder, dest));

            //Copy all the files
            foreach (string newPath in Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(folder, dest)); 
        }

        private List<string> FolderCompareForDeletedFiles(string sourceFolder, string destFolder)
        {
            System.IO.DirectoryInfo dirSource = new System.IO.DirectoryInfo(sourceFolder);
            System.IO.DirectoryInfo dirDest = new System.IO.DirectoryInfo(destFolder);

            // Take a snapshot of the file system.
            IEnumerable<System.IO.FileInfo> listFileSource = dirSource.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
            IEnumerable<System.IO.FileInfo> listFileDest = dirDest.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            //A custom file comparer defined below
            FileCompare myFileCompare = new FileCompare();            

            // Find file that are not inside source folder
            return listFileDest.Except(listFileSource, myFileCompare).Select(f => f.FullName).ToList();               
        }

        private List<string> FolderCompareForDeletedFolders(string sourceFolder, string destFolder)
        {
            System.IO.DirectoryInfo dirSource = new System.IO.DirectoryInfo(sourceFolder);
            System.IO.DirectoryInfo dirDest = new System.IO.DirectoryInfo(destFolder);

            // Take a snapshot of the file system.
            var listDirSource = dirSource.GetDirectories("*", System.IO.SearchOption.AllDirectories);
            var listDirDest = dirDest.GetDirectories("*.*", System.IO.SearchOption.AllDirectories);

            //A custom file comparer defined below
            DirectoryCompare myDirCompare = new DirectoryCompare();

            // Find file that are not inside source folder
            return listDirDest.Except(listDirSource, myDirCompare).Select(f => f.FullName).ToList();
        }
 
        private class FileCompare : System.Collections.Generic.IEqualityComparer<System.IO.FileInfo>
        {
            public FileCompare() { }

            public bool Equals(System.IO.FileInfo f1, System.IO.FileInfo f2)
            {
                return (f1.Name == f2.Name /*&& f1.Length == f2.Length*/);
            }

            // Return a hash that reflects the comparison criteria. According to the  
            // rules for IEqualityComparer<T>, if Equals is true, then the hash codes must 
            // also be equal. Because equality as defined here is a simple value equality, not 
            // reference identity, it is possible that two or more objects will produce the same 
            // hash code. 
            public int GetHashCode(System.IO.FileInfo fi)
            {
                string s = String.Format("{0}", fi.Name/*, fi.Length*/);
                return s.GetHashCode();
            }
        }

        private class DirectoryCompare : System.Collections.Generic.IEqualityComparer<System.IO.DirectoryInfo>
        {
            public DirectoryCompare() { }

            public bool Equals(System.IO.DirectoryInfo f1, System.IO.DirectoryInfo f2)
            {
                return (f1.Name == f2.Name /*&& f1.Length == f2.Length*/);
            }

            public int GetHashCode(System.IO.DirectoryInfo fi)
            {
                string s = String.Format("{0}", fi.Name/*, fi.Length*/);
                return s.GetHashCode();
            }
        }
    }
}
