using Microsoft.Synchronization;
using Microsoft.Synchronization.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VhostManager
{
    public class SyncManager
    {
        //public static bool IsSynch(string localPath, string vhostDomaineName)
        //{
        //    FileSyncOptions options = FileSyncOptions.ExplicitDetectChanges |
        // FileSyncOptions.RecycleDeletedFiles | FileSyncOptions.RecyclePreviousFileOnUpdates |
        // FileSyncOptions.RecycleConflictLoserFiles;
        //}


        public static SyncOperationStatistics DetectChanges(string localPath, string vhostDomainName, string shareHost, string shareUsername, string sharePassword, SyncDirection syncDirection)
        {
            return SyncProvider(localPath, vhostDomainName, shareHost, shareUsername, sharePassword, syncDirection, justStats: true);
        }

        public static SyncOperationStatistics Synchronize(string localPath, string vhostDomainName, string shareHost, string shareUsername, string sharePassword, SyncDirection syncDirection)
        {
            return SyncProvider(localPath, vhostDomainName, shareHost, shareUsername, sharePassword, syncDirection, justStats: false);
        }

        private static SyncOperationStatistics SyncProvider(string localPath, string vhostDomainName, string shareHost, string shareUsername, string sharePassword, SyncDirection syncDirection, bool justStats)
        {
            // Set options for the sync operation
            FileSyncOptions options = FileSyncOptions.CompareFileStreams;

            FileSyncScopeFilter filter = new FileSyncScopeFilter();
            filter.FileNameExcludes.Add("*.lnk"); // Exclude all *.lnk files
            filter.FileNameExcludes.Add("Thumbs.db");

            FileSyncProvider sourceProvider = null;
            FileSyncProvider targetProvider = null;

            SyncOperationStatistics stats = null;

            string uncPath = string.Format(@"\\{0}\vhosts\{1}\httpdocs", shareHost, vhostDomainName);
            var credentials = new NetworkCredential(shareUsername, sharePassword);

            try
            {
                using (new NetworkConnection(uncPath, credentials))
                {

                    sourceProvider = new FileSyncProvider(localPath, filter, options);
                    targetProvider = new FileSyncProvider(uncPath, filter, options);

                    sourceProvider.PreviewMode = justStats;
                    targetProvider.PreviewMode = justStats;

                    //targetProvider.AppliedChange += new EventHandler<AppliedChangeEventArgs>(OnAppliedChange);
                    //targetProvider.SkippedChange += new EventHandler<SkippedChangeEventArgs>(OnSkippedChange);

                    SyncOrchestrator agent = new SyncOrchestrator();
                    agent.LocalProvider = sourceProvider;
                    agent.RemoteProvider = targetProvider;

                    switch (syncDirection)
                    {
                        case SyncDirection.Upload: agent.Direction = SyncDirectionOrder.Upload;
                            break;
                        case SyncDirection.Download: agent.Direction = SyncDirectionOrder.Download;
                            break;
                        case SyncDirection.Both: agent.Direction = SyncDirectionOrder.UploadAndDownload; // Sync source to destination      
                            break;
                        default: agent.Direction = SyncDirectionOrder.UploadAndDownload;
                            break;
                    }

                    stats = agent.Synchronize();
                }

                return stats;
            }
            finally
            {
                // Release resources
                if (sourceProvider != null)
                {
                    sourceProvider.Dispose();
                }

                if (targetProvider != null)
                {
                    targetProvider.Dispose();
                }
            }
        }

    }
}
