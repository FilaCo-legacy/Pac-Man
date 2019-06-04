using System;
using System.Threading.Tasks;
using GameServer;
using GameServer.GameMap;

namespace MainWindow
{
    public class GameModel
    {
        private const float MaxValueAccum = 0.2f;

        public IScene Scene { get; }
        
        public IMap Map { get; }
        
        public IGameWindow Window { get; set; }

        public float DeltaTime { get; set; }

        public GameModel(IScene scene, IMap map, IGameWindow window, float fps = 60)
        {
            Map = map;
            Window = window;
            Scene = scene;
            DeltaTime = 1 / fps;
        }

        public void Execute()
        {
            var accumulator = 0.0f;
            var frameStartTime = DateTime.Now;

            while (true)
            {
                var curTime = DateTime.Now;
                var elapsedMilliseconds = (curTime - frameStartTime).TotalMilliseconds;

                frameStartTime = curTime;

                accumulator += (float) elapsedMilliseconds / 1000.0f;

                if (accumulator > MaxValueAccum)
                    accumulator = MaxValueAccum;

                while (accumulator > DeltaTime)
                {
                    Scene.Update();

                    accumulator -= DeltaTime;
                }

                Window.RenderGameFrame(accumulator / DeltaTime);
            }
        }

        public async Task ExecuteAsync() => await Task.Run(Execute);
    }
}