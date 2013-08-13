using System;
using System.Collections.Generic;

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