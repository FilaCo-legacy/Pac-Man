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
        private readonly IEnumerable<IRenderer> _renderers;

        public PacManSheet()
        {
            _renderers = new List<IRenderer>();
            HeightRequest = 248;
            WidthRequest = 224;
        }

        private void DrawPacMan(Context cr)
        {
            var pacMan = PacMan.GetInstance;

            var renderPositionX = _scaleX * (_prefRenderPositionX * _alpha + pacMan.Position.Column * (1.0f - _alpha));
            
            var renderPositionY = _scaleY * (_prefRenderPositionY * _alpha + pacMan.Position.Row * (1.0f - _alpha));
            
            cr.Translate(renderPositionX - 3, renderPositionY- 26);
            cr.SetSource(_pacManSurface[(int)pacMan.Direction, 2]);
            
            cr.Paint();

            //cr.Translate(-renderPositionX + 3, -renderPositionY+ 26);

            _prefRenderPositionX = renderPositionX / _scaleX;
            _prefRenderPositionY = renderPositionY / _scaleY;
        }

        protected override bool OnDrawn(Context cr)
        {
            foreach (var curRenderer in _renderers)
            {
                curRenderer.Draw(cr);
            }
            
            return true;
        }

        public void SetAlpha(float alpha)
        {
            foreach (var curRenderer in _renderers)
            {
                curRenderer.Alpha = alpha;
            }
        }
    }
}