namespace VhostManager
{
    public class HddSpaceInfos
    {
        public HddSpaceInfos()
        {
            this.Total = 0;
            this.Used = 0;
        }

        public int Total { get; set; }

        public int Used { get; set; }
    }
}