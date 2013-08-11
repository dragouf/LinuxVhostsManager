using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VhostManager
{
    public static class StringExtension
    {
        public static string ToFlatString(this IEnumerable<string> liste)
        {
            string result = string.Empty;
            foreach (var item in liste)
            {
                result += item + Environment.NewLine;
            }
            return result;
        }
    }
}
