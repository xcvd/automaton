namespace Automaton.WinApi
{
    /// <summary>
    /// A collection of WinApi constants used within automaton.
    /// </summary>
    internal class Constants
    {
        public const int

            // Low level mouse hook
            WhMouseLl = 14,

            // Left button down windows message
            WmLButtonDown = 0x0201,

            // Default cursor
            IdcArrow = 32512,

            // Crosshair cursor
            IdcCross = 32515,

            // BitBlt dwRop parameter
            SrcCopy = 0x00CC0020;
    }
}