using System;
using System.Threading.Tasks;
using GameServer.GameMap;
using GameServer.GameObjects;

namespace GameServer
{
    public class GameModel
    {
        private const float MaxValueAccum = 0.2f;
        
        public delegate void StepFinishedEventHandler(object sender, StepFinishedEventArgs args);
        public event StepFinishedEventHandler StepFinished;
        
        public IScene Scene { get; }

        public float DeltaTime { get; set; }

        public GameModel(IScene scene, float fps = 60)
        {
            Scene = scene;
            DeltaTime = 1 / fps;
        }
        
        private void OnStepFinished(object sender, StepFinishedEventArgs args)
        {
            StepFinished?.Invoke(sender, args);
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

                    accumulator += (float)elapsedMilliseconds / 1000.0f;

                    if (accumulator > MaxValueAccum)
                        accumulator = MaxValueAccum;

                    while (accumulator > DeltaTime)
                    {
                        Scene.Update();
                        accumulator -= DeltaTime;
                    }
                    
                    OnStepFinished(this,
                        new StepFinishedEventArgs(accumulator / DeltaTime));
                }
        }

        public Task ExecuteAsync() => Task.Run(Execute);
    }
}