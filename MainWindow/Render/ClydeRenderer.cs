using Cairo;
using GameServer.GameObjects.Ghosts;

namespace MainWindow.Render
{
    public class ClydeRenderer:IRenderer
    {
        private const string ClydeDir = @"Sprites/Ghosts/Clyde";

        private readonly ImageSurface[,] _clydeSurface;

        private float _prefRenderPositionX;

        private float _prefRenderPositionY;

        private readonly float _scaleX;

        private readonly float _scaleY;

        public float Alpha { get; set; }

        public ClydeRenderer()
        {
            _scaleX = _scaleY = 8;
            _prefRenderPositionX = Clyde.GetInstance.Position.Column * _scaleX;
            _prefRenderPositionY = Clyde.GetInstance.Position.Row * _scaleY;

            _clydeSurface = new[,]
            {
                {
                    new ImageSurface($"{ClydeDir}/Move_Right/Step1.png"),
                    new ImageSurface($"{ClydeDir}/Move_Right/Step2.png"),
                },
                {
                    new ImageSurface($"{ClydeDir}/Move_Down/Step1.png"),
                    new ImageSurface($"{ClydeDir}/Move_Down/Step2.png")
                },
                {
                    new ImageSurface($"{ClydeDir}/Move_Left/Step1.png"),
                    new ImageSurface($"{ClydeDir}/Move_Left/Step2.png")
                },
                {
                    new ImageSurface($"{ClydeDir}/Move_Up/Step1.png"),
                    new ImageSurface($"{ClydeDir}/Move_Up/Step2.png")
                },
            };
        }

        public void Draw(Context cr)
        {
            var clyde = Clyde.GetInstance;

            var renderPositionX = _prefRenderPositionX * Alpha + _scaleX * clyde.Position.Column * (1.0f - Alpha);

            var renderPositionY = _prefRenderPositionY * Alpha + _scaleY * clyde.Position.Row * (1.0f - Alpha);

            cr.Translate(renderPositionX - 3, renderPositionY - 26);
            cr.SetSource(_clydeSurface[(int) clyde.Direction, clyde.AnimateState]);

            cr.Paint();

            cr.Translate(-renderPositionX + 3, -renderPositionY + 26);

            _prefRenderPositionX = renderPositionX;
            _prefRenderPositionY = renderPositionY;
        }
    }
}