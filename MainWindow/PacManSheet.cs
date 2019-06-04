using System;
using System.Collections.Generic;
using Cairo;
using GameServer;
using GameServer.GameMap;
using GameServer.GameObjects;
using Gdk;
using GLib;
using Gtk;
using MainWindow.Render;
using Color = Cairo.Color;

namespace MainWindow
{
    public class PacManSheet: DrawingArea
    {
        private readonly IEnumerable<IRenderer> _renders;

        public PacManSheet()
        {
            _renders = new List<IRenderer>();
            HeightRequest = 248;
            WidthRequest = 224;
        }
    
        protected override bool OnDrawn(Context cr)
        {
            foreach (var curRenderer in _renders)
            {
                curRenderer.Draw(cr);
            }
            
            return true;
        }

        public void SetAlpha(float alpha)
        {
            foreach (var curRenderer in _renders)
            {
                curRenderer.Alpha = alpha;
            }
        }
    }
}