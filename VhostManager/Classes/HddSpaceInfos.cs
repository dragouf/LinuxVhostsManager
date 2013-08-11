using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
