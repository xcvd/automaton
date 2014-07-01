namespace Automaton.WinApi.Structs
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct LowLevelMouseHook
    {
        public Point Point;
        public int MouseData;
        public int Flags;
        public int Time;
        public UIntPtr ExtraInfo;
    }
}