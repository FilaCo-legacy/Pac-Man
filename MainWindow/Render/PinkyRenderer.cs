using Cairo;
using GameServer.GameObjects.Ghosts;

namespace MainWindow.Render
{
    public class PinkyRenderer :IRenderer
    {
        private const string PinkyDir = @"Sprites/Ghosts/Pinky";
        
        private readonly ImageSurface[,] _pinkySurface;
        
        private float _prefRenderPositionX;

        private float _prefRenderPositionY;
        
        private readonly float _scaleX;

        private readonly float _scaleY;

        public float Alpha { get; set; }

        public PinkyRenderer()
        {
            _scaleX = _scaleY = 8;
            _prefRenderPositionX = Pinky.GetInstance.Position.Column * _scaleX;
            _prefRenderPositionY = Pinky.GetInstance.Position.Row * _scaleY;

            _pinkySurface = new[,]
            {
                {new ImageSurface($"{PinkyDir}/Move_Right/Step1.png"), 
                    new ImageSurface($"{PinkyDir}/Move_Right/Step2.png"),
                },
                {new ImageSurface($"{PinkyDir}/Move_Down/Step1.png"),
                    new ImageSurface($"{PinkyDir}/Move_Down/Step2.png")},
                {new ImageSurface($"{PinkyDir}/Move_Left/Step1.png"),
                    new ImageSurface($"{PinkyDir}/Move_Left/Step2.png")},
                {new ImageSurface($"{PinkyDir}/Move_Up/Step1.png"),
                    new ImageSurface($"{PinkyDir}/Move_Up/Step2.png")},
            };
        }
        
        public void Draw(Context cr)
        {
            var pinky = Pinky.GetInstance;

            var renderPositionX = _prefRenderPositionX * Alpha + _scaleX * pinky.Position.Column * (1.0f - Alpha);
            
            var renderPositionY = _prefRenderPositionY * Alpha + _scaleY* pinky.Position.Row * (1.0f - Alpha);
            
            cr.Translate(renderPositionX - 3, renderPositionY- 26);
            cr.SetSource(_pinkySurface[(int)pinky.Direction, pinky.AnimateState]);
            
            cr.Paint();

            cr.Translate(-renderPositionX + 3, -renderPositionY+ 26);

            _prefRenderPositionX = renderPositionX;
            _prefRenderPositionY = renderPositionY;
        }
        
    }
}