using System.Collections.Generic;

namespace VhostManager
{
    public class VhostDetails
    {
        public string CheminLocal { get; set; }

        public string Nom { get; set; }

        public List<string> SousDomaines { get; set; }
    }
}