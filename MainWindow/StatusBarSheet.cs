using Cairo;
using Gtk;

namespace MainWindow
{
    public class StatusBarSheet : DrawingArea
    {
        protected override bool OnDrawn(Context cr)
        {
            return true;
        }
    }
}