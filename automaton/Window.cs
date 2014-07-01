namespace Automaton
{
    using System;
    using System.Drawing;
    using WinApi;
    using WinApi.Structs;
    using Point = WinApi.Structs.Point;

    /// <summary>
    /// The Window class represents a window selected for capture.
    /// </summary>
    public class Window
    {
        private readonly IntPtr windowHandle;
        private Rect rect;

        public Window(IntPtr handle)
        {
            this.windowHandle = handle;
            this.rect = new Rect();
            User32.GetWindowRect(this.windowHandle, ref this.rect);
        }

        public Window(int x, int y) :
            this(User32.WindowFromPoint(new Point(x, y)))
        {
        }

        public Window(System.Drawing.Point pt)
            : this(pt.X, pt.Y)
        {
        }

        public Rect Rect
        {
            get { return this.rect; }
            set { this.rect = value; }
        }

        public Image Capture()
        {
            var deviceSrc = User32.GetWindowDC(this.windowHandle);
            User32.GetWindowRect(this.windowHandle, ref this.rect);
            var deviceDest = Gdi32.CreateCompatibleDC(deviceSrc);
            var bitmapHandle = Gdi32.CreateCompatibleBitmap(
                deviceSrc,
                this.rect.Width,
                this.rect.Height);
            var oldHandle = Gdi32.SelectObject(deviceDest, bitmapHandle);
            Gdi32.BitBlt(
                deviceDest,
                0,
                0,
                this.rect.Width,
                this.rect.Height,
                deviceSrc,
                0,
                0,
                Constants.SrcCopy);
            Gdi32.SelectObject(deviceDest, oldHandle);
            Gdi32.DeleteDC(deviceDest);
            User32.ReleaseDC(this.windowHandle, deviceSrc);

            var img = Image.FromHbitmap(bitmapHandle);
            Gdi32.DeleteObject(bitmapHandle);

            return img;
        }

        public IntPtr GetParentHandle()
        {
            return User32.GetParent(this.windowHandle);
        }
    }
}