namespace Automaton
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using WinApi;
    using WinApi.Structs;

    /// <summary>
    /// Contains all mouse related functionality.
    /// </summary>
    public class MouseControl
    {
        private static int hookHandle;

        private static User32.HookProc mouseHookProcedure;

        private static Window pickedWindow;

        public static Window PickWindow()
        {
            User32.SetCursor(User32.LoadCursor(IntPtr.Zero, Constants.IdcCross));
            ActivateMouseHook();
            while (pickedWindow == null)
                Thread.Sleep(100);
            User32.SetCursor(User32.LoadCursor(IntPtr.Zero, Constants.IdcArrow));
            return pickedWindow;
        }

        private static void ActivateMouseHook()
        {
            if (hookHandle != 0) return;
            mouseHookProcedure = MouseHookProc;
            hookHandle = User32.SetWindowsHookEx(
                Constants.WhMouseLl,
                mouseHookProcedure,
                Kernel32.GetModuleHandle("user32"),
                0);
        }

        private static void DeactivateMouseHook()
        {
            User32.UnhookWindowsHookEx(hookHandle);
            hookHandle = 0;
        }

        private static IntPtr MouseHookProc(int code, UIntPtr wParam, IntPtr lParam)
        {
            var hookStruct = (LowLevelMouseHook)Marshal.PtrToStructure(lParam, typeof(LowLevelMouseHook));

            if (code < 0 || Constants.WmLButtonDown != wParam.ToUInt32())
                return User32.CallNextHookEx(hookHandle, code, wParam, lParam);

            pickedWindow = new Window(hookStruct.Point);
            var windowHandle = pickedWindow.GetParentHandle();
            while (windowHandle != IntPtr.Zero)
            {
                pickedWindow = new Window(windowHandle);
                windowHandle = pickedWindow.GetParentHandle();
            }

            DeactivateMouseHook();
            return User32.CallNextHookEx(hookHandle, code, wParam, lParam);
        }
    }
}