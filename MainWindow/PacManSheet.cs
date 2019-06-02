using System;
using Cairo;
using Gdk;
using Gtk;
using Color = Cairo.Color;

namespace MainWindow
{
    public class PacManSheet: DrawingArea
    {
        protected override bool OnDrawn(Context cr)
        {
            var surface = new ImageSurface(@"Map.png");

            cr.SetSource(surface);
           
            WidthRequest = surface.Width;
            HeightRequest = surface.Height;
            cr.Paint();
            return true;
        }
    }
}