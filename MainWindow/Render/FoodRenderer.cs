using Cairo;
using GameServer.GameObjects;

namespace MainWindow.Render
{
    public class FoodRenderer : IRenderer
    {
        private const string FoodDir = @"Sprites/Food";
        
        private readonly ImageSurface _foodSurface;

        private readonly ImageSurface _energizerSurface;

        private readonly float _scaleX;

        private readonly float _scaleY;
        
        public float Alpha { get; set; }

        public FoodRenderer()
        {
            _scaleX = _scaleY = 8;
            
            _foodSurface = new ImageSurface($"{FoodDir}/Food.png");
            
            _energizerSurface = new ImageSurface($"{FoodDir}/Energizer.png");
        }
        
        public void Draw(Context cr)
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
    }
}