using System;

namespace GameServer
{
    public class GameLoop
    {
        private const float MaxValueAccum = 0.2f;
        
        public delegate void StepFinishedEventHandler(object sender, StepFinishedEventArgs args);
        
        public event StepFinishedEventHandler StepFinished;

        public float DeltaTime => 1.0f / FramePerSecond;
        
        public float FramePerSecond { get; set; }

        public GameLoop(Map sceneMap)
        {
            FramePerSecond = 60;
        }

        public void Execute()
        {
            var accumulator = 0.0f;
            var frameStartTime = DateTime.Now.Millisecond;
            
            while (true)
            {
                var curTime = DateTime.Now.Millisecond;
                
                accumulator += (curTime - frameStartTime) / 1000.0f;

                frameStartTime = curTime;

                if (accumulator > MaxValueAccum)
                    accumulator = MaxValueAccum;

                while (accumulator > DeltaTime)
                {
                    Scene.GetInstance.Update();
                    accumulator -= DeltaTime;
                }
                
                OnStepFinished(this, new StepFinishedEventArgs(accumulator/DeltaTime));
            }
        }

        public void OnStepFinished(object sender, StepFinishedEventArgs args)
        {
            StepFinished?.Invoke(sender, args);
        }
    }
}