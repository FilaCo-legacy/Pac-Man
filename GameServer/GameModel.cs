using System;
using System.Threading.Tasks;
using GameServer.GameMap;
using GameServer.GameObjects;

namespace GameServer
{
    public class GameModel
    {
        private const double MaxValueAccum = 0.2;
        
        public delegate void StepFinishedEventHandler(object sender, StepFinishedEventArgs args);
        public event StepFinishedEventHandler StepFinished;
        
        public IScene Scene { get; }
        
        public IMap Map { get; set; }
        
        public double DeltaTime { get; set; }

        public GameModel(IScene scene, IMap map, double fps = 60)
        {
            Scene = scene;
            Map = map;
            DeltaTime = 1 / fps;
        }
        
        private void OnStepFinished(object sender, StepFinishedEventArgs args)
        {
            StepFinished?.Invoke(sender, args);
        }

        public void Execute()
        {
            var accumulator = 0.0;
            var frameStartTime = DateTime.Now;
            
                while (true)
                {
                    var curTime = DateTime.Now;
                    var elapsedMilliseconds = (curTime - frameStartTime).TotalMilliseconds;

                    frameStartTime = curTime;

                    accumulator += elapsedMilliseconds / 1000.0;

                    if (accumulator > MaxValueAccum)
                        accumulator = MaxValueAccum;

                    while (accumulator > DeltaTime)
                    {
                        Scene.Update();
                        accumulator -= DeltaTime;
                    }
                    
                    OnStepFinished(this,
                        new StepFinishedEventArgs(accumulator / DeltaTime, elapsedMilliseconds));
                }
        }

        public Task ExecuteAsync() => Task.Run(Execute);
    }
}