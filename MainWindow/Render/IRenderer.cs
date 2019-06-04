using Cairo;

namespace MainWindow.Render
{
    public interface IRenderer
    {
        float Alpha { get; set; }
        
        void Draw(Context cr);
    }
}