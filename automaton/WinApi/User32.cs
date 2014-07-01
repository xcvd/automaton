namespace Automaton.WinApi
{
    using System;
    using System.Runtime.InteropServices;
    using Structs;

    /// <summary>
    /// Contains PInvoke signatures for user32.dll functions.
    /// </summary>
    internal class User32
    {
        public delegate IntPtr HookProc(int code, UIntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(
            int hookId,
            int code,
            UIntPtr wParam,
            IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr windowHandle);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursor(IntPtr instance, int cursor);

        [DllImport("user32.dll")]
        public static extern void mouse_event(
            int flags,
            int x,
            int y,
            int data,
            int extraInfo);

        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr dc);

        [DllImport("user32.dll")]
        public static extern IntPtr SetCursor(IntPtr cursorHandle);

        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(
            int hookId,
            HookProc function,
            IntPtr instance,
            int threadId);

        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(int hookId);

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point point);
    }
}