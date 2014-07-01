namespace Automaton.WinApi
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains PInvoke signatures for kernel32.dll functions.
    /// </summary>
    internal class Kernel32
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string moduleName);
    }
}
