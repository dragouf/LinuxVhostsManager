using System;

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