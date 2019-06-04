using Cairo;
using GameServer.GameObjects;
using GameServer.GameObjects.Ghosts;
using GameServer.GameObjects.Ghosts.GhostStates;

namespace MainWindow.Render
{
    public class BlinkyRenderer : IRenderer
    {
        private const string BlinkyDir = @"Sprites/Ghosts/Blinky";

        private const string FrightenedDir = @"Sprites/Ghosts/Frightened";
        
        private readonly ImageSurface[,] _blinkySurface;

        private readonly ImageSurface[] _frighetenedSurface;
        
        private float _prefRenderPositionX;

        private float _prefRenderPositionY;
        
        private readonly float _scaleX;

        private readonly float _scaleY;

        public float Alpha { get; set; }

        public BlinkyRenderer()
        {
            _scaleX = _scaleY = 8;
            _prefRenderPositionX = Blinky.GetInstance.Position.Column * _scaleX;
            _prefRenderPositionY = Blinky.GetInstance.Position.Row * _scaleY;

            _blinkySurface = new[,]
            {
                {new ImageSurface($"{BlinkyDir}/Move_Right/Step1.png"), 
                    new ImageSurface($"{BlinkyDir}/Move_Right/Step2.png")},
                {new ImageSurface($"{BlinkyDir}/Move_Down/Step1.png"),
                    new ImageSurface($"{BlinkyDir}/Move_Down/Step2.png")},
                {new ImageSurface($"{BlinkyDir}/Move_Left/Step1.png"),
                    new ImageSurface($"{BlinkyDir}/Move_Left/Step2.png")},
                {new ImageSurface($"{BlinkyDir}/Move_Up/Step1.png"),
                    new ImageSurface($"{BlinkyDir}/Move_Up/Step2.png")},
            };
            
            _frighetenedSurface = new[]
            {
                new ImageSurface($"{FrightenedDir}/Step1.png"),
                new ImageSurface($"{FrightenedDir}/Step2.png")
            };
        }
        
        public void Draw(Context cr)
        {
            var blinky = Blinky.GetInstance;

            var renderPositionX = _prefRenderPositionX * Alpha + _scaleX * blinky.Position.Column * (1.0f - Alpha);
            
            var renderPositionY = _prefRenderPositionY * Alpha + _scaleY* blinky.Position.Row * (1.0f - Alpha);
            
            cr.Translate(renderPositionX - 3, renderPositionY- 26);
            
            if (blinky.State is FrightenedState)
                cr.SetSource(_frighetenedSurface[blinky.AnimateState]);
            else
                cr.SetSource(_blinkySurface[(int)blinky.Direction, blinky.AnimateState]);
            
            cr.Paint();

            cr.Translate(-renderPositionX + 3, -renderPositionY+ 26);

            _prefRenderPositionX = renderPositionX;
            _prefRenderPositionY = renderPositionY;
        }

    }
}