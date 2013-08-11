using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VhostManager
{
    public class VhostDetails
    {
        public string Nom { get; set; }
        public List<string> SousDomaines { get; set; }
        public string CheminLocal { get; set; }
    }
}
