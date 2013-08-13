using Microsoft.Synchronization;
using Microsoft.Synchronization.Files;
using System;
using System.Net;

namespace VhostManager
{
    public class SyncManager : IDisposable
    {
        public SyncManager(string localPath, string shareHost, string vhostDomainName)
        {
            this.UncPath = string.Format(@"\\{0}\vhosts\{1}\httpdocs", shareHost, vhostDomainName);
            this.LocalPath = localPath;

            InitializeSyncAgent();
        }

        private SyncOrchestrator AgentOrcherstrator { get; set; }

        private string LocalPath { get; set; }

        private FileSyncProvider SourceProvider { get; set; }

        private FileSyncProvider TargetProvider { get; set; }

        private string UncPath { get; set; }

        public SyncOperationStatistics DetectChanges(string shareUsername, string sharePassword, SyncDirection syncDirection)
        {
            return SyncProvider(shareUsername, sharePassword, syncDirection, justStats: true);
        }

        public void Dispose()
        {
            if (AgentOrcherstrator != null)
            {
                if (AgentOrcherstrator.State != SyncOrchestratorState.Ready &&
                    AgentOrcherstrator.State != SyncOrchestratorState.Canceled &&
                    AgentOrcherstrator.State != SyncOrchestratorState.Canceling)
                {
                    AgentOrcherstrator.Cancel();
                }
            }

            // Release resources
            if (SourceProvider != null)
            {
                SourceProvider.Dispose();
            }

            if (TargetProvider != null)
            {
                TargetProvider.Dispose();
            }
        }

        public SyncOperationStatistics Synchronize(string shareUsername, string sharePassword, SyncDirection syncDirection)
        {
            return SyncProvider(shareUsername, sharePassword, syncDirection, justStats: false);
        }

        private void InitializeSyncAgent()
        {
            // Set options for the sync operation
            FileSyncOptions options = FileSyncOptions.CompareFileStreams;

            FileSyncScopeFilter filter = new FileSyncScopeFilter();
            filter.FileNameExcludes.Add("*.lnk"); // Exclude all *.lnk files
            filter.FileNameExcludes.Add("Thumbs.db");

            this.SourceProvider = new FileSyncProvider(this.LocalPath, filter, options);
            this.TargetProvider = new FileSyncProvider(this.UncPath, filter, options);

            this.AgentOrcherstrator = new SyncOrchestrator();
            this.AgentOrcherstrator.LocalProvider = SourceProvider;
            this.AgentOrcherstrator.RemoteProvider = TargetProvider;
        }

        private SyncOperationStatistics SyncProvider(string shareUsername, string sharePassword, SyncDirection syncDirection, bool justStats)
        {
            if (SourceProvider == null || TargetProvider == null || AgentOrcherstrator == null)
                throw new Exception("La synchronisation n'a pas pu démarrer.");

            SyncOperationStatistics stats = null;
            var credentials = new NetworkCredential(shareUsername, sharePassword);

            try
            {
                using (new NetworkConnection(this.UncPath, credentials))
                {
                    SourceProvider.PreviewMode = justStats;
                    TargetProvider.PreviewMode = justStats;

                    //targetProvider.AppliedChange += new EventHandler<AppliedChangeEventArgs>(OnAppliedChange);
                    //targetProvider.SkippedChange += new EventHandler<SkippedChangeEventArgs>(OnSkippedChange);

                    switch (syncDirection)
                    {
                        case SyncDirection.Upload: this.AgentOrcherstrator.Direction = SyncDirectionOrder.Upload;
                            break;

                        case SyncDirection.Download: this.AgentOrcherstrator.Direction = SyncDirectionOrder.Download;
                            break;

                        case SyncDirection.Both: this.AgentOrcherstrator.Direction = SyncDirectionOrder.UploadAndDownload; // Sync source to destination
                            break;

                        default: this.AgentOrcherstrator.Direction = SyncDirectionOrder.UploadAndDownload;
                            break;
                    }

                    stats = this.AgentOrcherstrator.Synchronize();
                }

                return stats;
            }
            finally
            {
                // Release resources
                //if (SourceProvider != null)
                //{
                //    SourceProvider.Dispose();
                //}

                //if (TargetProvider != null)
                //{
                //    TargetProvider.Dispose();
                //}
            }
        }
    }
}