namespace Automaton.WinApi
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Gdi32
    {
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(
            IntPtr objectHandle,
            int xDest,
            int yDest,
            int width,
            int height,
            IntPtr objectSource,
            int xSrc,
            int ySrc,
            int rop);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(
            IntPtr dc,
            int width,
            int height);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr dc);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr dc);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr objectHandle);

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr dc, IntPtr objectHandle);
    }
}
