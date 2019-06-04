using System.Collections.Generic;
using Cairo;
using Gtk;
using MainWindow.Render;

namespace MainWindow
{
    public class PacManSheet : DrawingArea
    {
        private readonly IList<IRenderer> _renders;

        public PacManSheet()
        {
            _renders = new List<IRenderer>();
            HeightRequest = 248;
            WidthRequest = 224;
        }

        protected override bool OnDrawn(Context cr)
        {
            foreach (var curRenderer in _renders) curRenderer.Draw(cr);

            return true;
        }

        public void SetAlpha(float alpha)
        {
            foreach (var curRenderer in _renders) curRenderer.Alpha = alpha;
        }

        public void AddRenderer(IRenderer renderer)
        {
            _renders.Add(renderer);
        }
    }
}