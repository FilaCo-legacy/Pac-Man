using Cairo;
using GameServer.GameObjects;

namespace MainWindow.Render
{
    
    // TODO: Implement animation
    public class PacManRenderer : IRenderer
    {
        private const int States = 3;
        
        private const string PacManDir = @"Sprites/Pac-Man";
        
        private readonly ImageSurface[,] _pacManSurface;
        
        private float _prefRenderPositionX;

        private float _prefRenderPositionY;
        
        private readonly float _scaleX;

        private readonly float _scaleY;
        
        public float Alpha { get; set; }

        public PacManRenderer()
        {
            _scaleX = _scaleY = 8;
            _prefRenderPositionX = PacMan.GetInstance.Position.Column;
            _prefRenderPositionY = PacMan.GetInstance.Position.Row;
            
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
        
        public void Draw(Context cr)
        {
            var pacMan = PacMan.GetInstance;

            var renderPositionX = _scaleX * (_prefRenderPositionX * Alpha + pacMan.Position.Column * (1.0f - Alpha));
            
            var renderPositionY = _scaleY * (_prefRenderPositionY * Alpha + pacMan.Position.Row * (1.0f - Alpha));
            
            cr.Translate(renderPositionX - 3, renderPositionY- 26);
            cr.SetSource(_pacManSurface[(int)pacMan.Direction, 2]);
            
            cr.Paint();

            cr.Translate(-renderPositionX + 3, -renderPositionY+ 26);

            _prefRenderPositionX = renderPositionX / _scaleX;
            _prefRenderPositionY = renderPositionY / _scaleY;
        }

    }
}