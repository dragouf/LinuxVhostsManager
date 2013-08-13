using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;

namespace HostsFileUnlocker
{
    internal class Program
    {
        private static string HostFile = @"C:\Windows\System32\Drivers\etc\hosts";

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private static void Main(string[] args)
        {
            Console.WindowHeight = 10;
            Console.WindowWidth = 10;
            Console.Title = "HostsUnlocker";
            //Sometimes System.Windows.Forms.Application.ExecutablePath works for the caption depending on the system you are running under.
            IntPtr hWnd = FindWindow(null, Console.Title); //put your console window caption here
            if (hWnd != IntPtr.Zero)
            {
                //Hide the window
                ShowWindow(hWnd, 0); // 0 = SW_HIDE
            }

            try
            {
                using (var user = WindowsIdentity.GetCurrent())
                {
                    var ownerSecurity = new FileSecurity();
                    ownerSecurity.SetOwner(user.User);
                    File.SetAccessControl(HostFile, ownerSecurity);

                    var accessSecurity = new FileSecurity();
                    accessSecurity.AddAccessRule(new FileSystemAccessRule(user.User, FileSystemRights.FullControl, AccessControlType.Allow));
                    File.SetAccessControl(HostFile, accessSecurity);
                }
            }
            catch
            {
                Environment.Exit(-1);
            }

            Environment.Exit(0);

            //Console.ReadLine();
        }

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}