using System;
using Cairo;
using GameServer;
using GameServer.GameMap;
using GameServer.GameObjects;
using Gdk;
using GLib;
using Gtk;
using Color = Cairo.Color;

namespace MainWindow
{
    public class PacManSheet: DrawingArea
    {
        private const int States = 3;
        
        private const string PacManDir = @"Sprites/Pac-Man";

        private const string GhostsDir = @"Sprites/Ghosts";

        private const string FoodDir = @"Sprites/Food";

        private const string MapPath = @"Map.png";

        private ImageSurface _mapSurface;

        private ImageSurface _foodSurface;

        private ImageSurface _energizerSurface;

        private ImageSurface[,] _pacManSurface;
        
        private double _scaleX;

        private double _scaleY;

        private double _alpha;

        public PacManSheet()
        {
            InitSurfaces();
        }

        private void InitSurfaces()
        {
            _mapSurface = new ImageSurface(MapPath);
            _foodSurface = new ImageSurface($"{FoodDir}/Food.png");
            _energizerSurface = new ImageSurface($"{FoodDir}/Energizer.png");
            
            _pacManSurface = new[,]
            {
                {new ImageSurface($"{PacManDir}/Move_Right/Full.png"), 
                    new ImageSurface($"{PacManDir}/Move_Right/Intermediate.png"), 
                    new ImageSurface($"{PacManDir}/Move_Right/OpenMouth.png")},
                {new ImageSurface($"{PacManDir}/Move_Down/Full.png"), 
                    new ImageSurface($"{PacManDir}/Move_Down/Intermediate.png"), 
                    new ImageSurface($"{PacManDir}/Move_Down/OpenMouth.png")},
                {new ImageSurface($"{PacManDir}/Move_Left/Full.png"), 
                    new ImageSurface($"{PacManDir}/Move_Left/Intermediate.png"), 
                    new ImageSurface($"{PacManDir}/Move_Left/OpenMouth.png")},
                {new ImageSurface($"{PacManDir}/Move_Up/Full.png"), 
                    new ImageSurface($"{PacManDir}/Move_Up/Intermediate.png"), 
                    new ImageSurface($"{PacManDir}/Move_Up/OpenMouth.png")},
            };
        }

        private void DrawMap(Context cr)
        {
            if (AllocatedHeight < _mapSurface.Height)
                HeightRequest = _mapSurface.Height;
            
            if (AllocatedWidth < _mapSurface.Height)
                WidthRequest = _mapSurface.Width;
            
            _scaleY = _mapSurface.Height*1.0/(GameServer.GameMap.Map.GetInstance.Height - 5);
            _scaleX = _mapSurface.Width*1.0/GameServer.GameMap.Map.GetInstance.Width;

            cr.SetSource(_mapSurface);
            
            cr.Paint();
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
            cr.Translate(0, _scaleY*4);
        }

        private void DrawPacMan(Context cr)
        {
            var pacMan = PacMan.GetInstance;
            
            cr.Translate(pacMan.Position.Column * _scaleX , (pacMan.Position.Row* _scaleY  - 2));
            cr.SetSource(_pacManSurface[(int)pacMan.Direction, 2]);
            
            cr.Paint();

            cr.Translate(-pacMan.Position.Column * _scaleX , -(pacMan.Position.Row* _scaleY  - 2));
        }

        protected override bool OnDrawn(Context cr)
        {
            DrawMap(cr);
            DrawFood(cr);
            DrawPacMan(cr);
            
            return true;
        }
    }
}