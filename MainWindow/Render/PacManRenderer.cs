using Cairo;

namespace MainWindow.Render
{
    public class PacManRenderer
    {
        private const int States = 3;
        
        private const string PacManDir = @"Sprites/Pac-Man";
        
        private ImageSurface[,] _pacManSurface;
        
        private float _prefRenderPositionX;

        private float _prefRenderPositionY;

        public PacManRenderer()
        {
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
    }
}