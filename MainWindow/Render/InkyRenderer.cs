using Cairo;
using GameServer.GameObjects.Ghosts;
using GameServer.GameObjects.Ghosts.GhostStates;

namespace MainWindow.Render
{
    public class InkyRenderer : IRenderer
    {
        private const string InkyDir = @"Sprites/Ghosts/Inky";
        
        private const string FrightenedDir = @"Sprites/Ghosts/Frightened";
        
        private const string RespawnDir = @"Sprites/Ghosts/Respawn";

        private readonly ImageSurface[,] _inkySurface;
        
        private readonly ImageSurface[] _frighetenedSurface;
        
        private readonly ImageSurface[] _respawnSurface;

        private float _prefRenderPositionX;

        private float _prefRenderPositionY;

        private readonly float _scaleX;

        private readonly float _scaleY;

        public float Alpha { get; set; }

        public InkyRenderer()
        {
            _scaleX = _scaleY = 8;
            _prefRenderPositionX = Inky.GetInstance.Position.Column * _scaleX;
            _prefRenderPositionY = Inky.GetInstance.Position.Row * _scaleY;

            _inkySurface = new[,]
            {
                {
                    new ImageSurface($"{InkyDir}/Move_Right/Step1.png"),
                    new ImageSurface($"{InkyDir}/Move_Right/Step2.png"),
                },
                {
                    new ImageSurface($"{InkyDir}/Move_Down/Step1.png"),
                    new ImageSurface($"{InkyDir}/Move_Down/Step2.png")
                },
                {
                    new ImageSurface($"{InkyDir}/Move_Left/Step1.png"),
                    new ImageSurface($"{InkyDir}/Move_Left/Step2.png")
                },
                {
                    new ImageSurface($"{InkyDir}/Move_Up/Step1.png"),
                    new ImageSurface($"{InkyDir}/Move_Up/Step2.png")
                },
            };
            
            _frighetenedSurface = new[]
            {
                new ImageSurface($"{FrightenedDir}/Step1.png"),
                new ImageSurface($"{FrightenedDir}/Step2.png")
            };
            
            _respawnSurface = new[]
            {
                new ImageSurface($"{RespawnDir}/Move_Right.png"),
                new ImageSurface($"{RespawnDir}/Move_Down.png"),
                new ImageSurface($"{RespawnDir}/Move_Left.png"),
                new ImageSurface($"{RespawnDir}/Move_Up.png"),
            };
        }

        public void Draw(Context cr)
        {
            var inky = Inky.GetInstance;

            var renderPositionX = _prefRenderPositionX * Alpha + _scaleX * inky.Position.Column * (1.0f - Alpha);

            var renderPositionY = _prefRenderPositionY * Alpha + _scaleY * inky.Position.Row * (1.0f - Alpha);

            cr.Translate(renderPositionX - 3, renderPositionY - 26);
            
            if (inky.State is FrightenedState)
                cr.SetSource(_frighetenedSurface[inky.AnimateState]);
            else if (inky.State is RespawnState)
                cr.SetSource(_respawnSurface[inky.AnimateState]);
            else
                cr.SetSource(_inkySurface[(int) inky.Direction, inky.AnimateState]);

            cr.Paint();

            cr.Translate(-renderPositionX + 3, -renderPositionY + 26);

            _prefRenderPositionX = renderPositionX;
            _prefRenderPositionY = renderPositionY;
        }
    }
}