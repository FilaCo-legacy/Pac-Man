using System;
using Cairo;
using GameServer.GameMap;
using Gdk;
using Gtk;
using Color = Cairo.Color;

namespace MainWindow
{
    public class PacManSheet: DrawingArea
    {
        private double scaleX;

        private double scaleY;
        
        public Map PacManMap { get; set; }
        
        protected override bool OnDrawn(Context cr)
        {
            var surface = new ImageSurface(@"Map.png");

            scaleX = WidthRequest / surface.Width;
            scaleY = HeightRequest / surface.Height;
            
            cr.SetSource(surface);
            
            cr.Scale(scaleX, scaleY);
            
            cr.Paint();
            return true;
        }
    }
}