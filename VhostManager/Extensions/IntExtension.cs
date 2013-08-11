using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VhostManager
{
    public static class IntExtension
    {
        public static TEnum ToEnum<TEnum>(this int value)
        {
            return (TEnum)Enum.ToObject(typeof(TEnum), value);
        }
    }
}
