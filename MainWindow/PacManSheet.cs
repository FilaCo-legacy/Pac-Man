using System;
using Cairo;
using GameServer;
using GameServer.GameMap;
using GameServer.GameObjects;
using Gdk;
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
        
        private  double _scaleX;

        private double _scaleY;

        private int _pacManState;
        
        public IMap PacManMap { get; set; }

        public PacManSheet()
        {
            InitSurfaces();
            _pacManState = 0;
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
            
            _scaleY = _mapSurface.Height*1.0/(PacManMap.Height - 5);
            _scaleX = _mapSurface.Width*1.0/PacManMap.Width;

            cr.SetSource(_mapSurface);
            
            cr.Paint();
        }

        private void DrawFood(Context cr)
        {
            cr.Translate(0, -_scaleY*4);
            
            for (var row = 0; row < PacManMap.Height; ++row)
            {
                cr.Translate( 0, _scaleY);
                for (var col = 0; col < PacManMap.Width; ++col)
                {
                    if (PacManMap[row, col] == MapObjCode.Food)
                    {
                        cr.SetSource(_foodSurface);
                        cr.Paint();
                    }
                    else if (PacManMap[row, col] == MapObjCode.Energizer)
                    {
                        cr.SetSource(_energizerSurface);
                        cr.Paint();
                    }
                    cr.Translate(_scaleX, 0);
                    
                }
                cr.Translate(- PacManMap.Width*_scaleX, 0);
            }
            
            cr.Translate(0, - PacManMap.Height*_scaleY);
            cr.Translate(0, _scaleY*4);
        }

        private void DrawPacMan(Context cr)
        {
            var pacMan = PacMan.GetInstance;
            
            cr.Translate(pacMan.Position.Column * _scaleX, pacMan.Position.Row * _scaleY);
            cr.SetSource(_pacManSurface[(int)pacMan.Direction, _pacManState]);
            
            cr.Paint();

            cr.Translate(-pacMan.Position.Column * _scaleX, -pacMan.Position.Row * _scaleY);

        }

        public void OnStepFinished(object sender, StepFinishedEventArgs args)
        {

            DrawMap(cr);
            DrawFood(cr);
            DrawPacMan(cr);
        }
    }
}