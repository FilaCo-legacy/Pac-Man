using Cairo;

namespace MainWindow.Render
{
    public class MapRenderer:IRenderer
    {
        private const string MapDir = "Map.png";

        private readonly ImageSurface _mapSurface;
        
        public float Alpha { get; set; }

        public MapRenderer()
        {
            _mapSurface = new ImageSurface(MapDir);
        }
        
        public void Draw(Context cr)
        {
            cr.SetSource(_mapSurface);
            cr.Paint();
        }
    }
}