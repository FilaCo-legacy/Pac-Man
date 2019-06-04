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

        private void DrawFood(Context cr)
        {
            cr.Translate(0, -_scaleY*4);

            var map = GameServer.GameMap.Map.GetInstance;
            
            for (var row = 0; row < map.Height; ++row)
            {
                cr.Translate( 0, _scaleY);
                for (var col = 0; col < map.Width; ++col)
                {
                    if (map[row, col] == MapObjCode.Food)
                    {
                        cr.SetSource(_foodSurface);
                        cr.Paint();
                    }
                    else if (map[row, col] == MapObjCode.Energizer)
                    {
                        cr.SetSource(_energizerSurface);
                        cr.Paint();
                    }
                    cr.Translate(_scaleX, 0);
                    
                }
                cr.Translate(- map.Width*_scaleX, 0);
            }
            
            cr.Translate(0, - map.Height*_scaleY);
            cr.Translate(0, 4*_scaleY);
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