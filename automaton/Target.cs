namespace Automaton
{
    using System.Drawing;
    using AForge.Imaging;
    using Image = System.Drawing.Image;

    /// <summary>
    /// The target class represents image to be found on the screen.
    /// </summary>
    public class Target
    {
        private readonly Image image;
        private TemplateMatch[] matches;

        public Target(Image image)
        {
            this.image = image;
        }

        public Point Centre 
        {
            get
            {
                if (this.matches == null || this.matches.Length > 1)
                    return Point.Empty;

                var rect = this.matches[0].Rectangle;
                return new Point(
                    rect.X + (rect.Width / 2),
                    rect.Y + (rect.Height / 2));
            }
        }

        public bool FindInWindow(Window targetWindow)
        {
            var matcher = new ExhaustiveTemplateMatching();
            var results = matcher.ProcessImage(
                (Bitmap)targetWindow.Capture(),
                (Bitmap)this.image);
            if (results.Length == 0) return false;
            this.matches = results;
            return true;
        }
    }
}