using System;

namespace DmxSharp.Extensions
{
    public static class FloatExtensions
    {
        public static bool AlmostEquals(this double double1, double double2, double precision)
        {
            return Math.Abs(double1 - double2) <= precision;
        }

        public static bool AlmostZero(this double value)
        {
            return value.AlmostEquals(0.0, 0.0000001);
        }

        public static byte Bytify(this double value)
        {
            var rounded = Math.Round((decimal) value);
            return (byte) Math.Max(0, Math.Min(255, rounded));
        }
    }
}