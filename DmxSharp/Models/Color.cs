using System;
using System.Collections.Generic;
using System.Text;
using DmxSharp.Extensions;

namespace DmxSharp.Models
{
    public struct Color
    {
        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }
        public bool IsActive => !R.AlmostZero() || !G.AlmostZero() || !B.AlmostZero();

        public (byte R, byte G, byte B) Bytify()
        {
            return (R: R.Bytify(), G: G.Bytify(), B: B.Bytify());
        }

        public System.Drawing.Color GetDrawingColor()
        {
            var bytified = Bytify();
            return System.Drawing.Color.FromArgb(bytified.R, bytified.R, bytified.R);
        }

        public bool IsGrey()
        {
            var b = Bytify();
            return b.R == b.G && b.R == b.B;
        }

        public byte[] GetRgb()
        {
            var b = Bytify();
            return new[] { b.R, b.G, b.B };
        }

        public byte[] GetDrgb()
        {
            var b = Bytify();
            // ToDo: improve this to achieve higher resolution
            return new[] { (byte)255, b.R, b.G, b.B };
        }

        public byte[] GetRgbw()
        {
            var b = Bytify();
            // ToDo: improve this to achieve higher resolution
            if (IsGrey()) return new [] { (byte)0, (byte)0, (byte)0, b.R };
            return new[] { b.R, b.G, b.B, (byte)0 };
        }

        public static readonly Color Black = new Color() { R = 0.0, G = 0.0, B = 0.0 };
        public static readonly Color White = new Color() { R = 255.0, G = 255.0, B = 255.0 };
        public static readonly Color Red = new Color() { R = 255.0, G = 0.0, B = 0.0 };
        public static readonly Color Green = new Color() { R = 0.0, G = 255.0, B = 0.0 };
        public static readonly Color Blue = new Color() { R = 0.0, G = 0.0, B = 255.0 };
    }
}
