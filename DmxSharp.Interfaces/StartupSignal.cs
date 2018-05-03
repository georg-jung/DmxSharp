using System;
using System.Collections.Generic;
using System.Text;

namespace DmxSharp.Interfaces
{
    public sealed class StartupSignal : ISignal
    {
        private static readonly Lazy<StartupSignal> Lazy = new Lazy<StartupSignal>(() => new StartupSignal());

        public static StartupSignal Value => Lazy.Value;

        private StartupSignal()
        {
        }

    }
}
