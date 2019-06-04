using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GameServer;

namespace MainWindow
{
    public class GameModel
    {
        private readonly float _maxValueAccum;

        public IScene Scene { get; }
        
        public IGameWindow Window { get; set; }

        public float DeltaTime { get; set; }

        public GameModel(IScene scene, IGameWindow window, float fps = 30)
        {
            Window = window;
            Scene = scene;
            DeltaTime = 1 / fps;
            _maxValueAccum = DeltaTime * 5;
        }

        public void Execute()
        {
            var accumulator = 0.0f;
            var frameTimeStart = DateTime.Now;

            while (true)
            {
                var elapsedMilliseconds = (DateTime.Now - frameTimeStart).TotalMilliseconds;

                accumulator += (float)elapsedMilliseconds/1000.0f;

                if (accumulator > _maxValueAccum)
                    accumulator = _maxValueAccum;

                while (DateTime.Now > frameTimeStart && accumulator >= DeltaTime)
                {
                    Scene.Update();

                    accumulator -= DeltaTime;

                    frameTimeStart = frameTimeStart.AddSeconds(DeltaTime);
                }
                
                if (frameTimeStart > DateTime.Now)
                    frameTimeStart = DateTime.Now;
                
                Window.RenderGameFrame(accumulator / DeltaTime);
            }
        }

        public async Task ExecuteAsync() => await Task.Run(Execute);
    }
}