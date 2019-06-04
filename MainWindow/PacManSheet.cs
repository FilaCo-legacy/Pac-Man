using System.Collections.Generic;
using Cairo;
using Gdk;
using Gtk;
using MainWindow.Render;

namespace MainWindow
{
    public class PacManSheet : DrawingArea
    {
        private readonly IList<IRenderer> _renders;

        private readonly ImageSurface[] _image;

        private int _curBuffer;

        public PacManSheet()
        {
            _renders = new List<IRenderer>();
            
            _image = new [] { new ImageSurface(Format.ARGB32, 224, 248), 
                new ImageSurface(Format.ARGB32, 224, 248), };
            
            _curBuffer = 0;
            
            HeightRequest = 248;
            WidthRequest = 224;
        }

        protected override bool OnDrawn(Context cr)
        {
            cr.SetSource(_image[1 - _curBuffer]);
            cr.Paint();
            _curBuffer = 1 - _curBuffer;
            return true;
        }

        public void RenderBuffer(float alpha)
        {
            using (var cr = new Context(_image[_curBuffer]))
            {
                foreach (var curRenderer in _renders)
                {
                    curRenderer.Alpha = alpha;
                    curRenderer.Draw(cr);
                }
            }
        }

        public void AddRenderer(IRenderer renderer)
        {
            _renders.Add(renderer);
        }
    }
}