using System;
using GameServer.GameMap;
using GameServer.GameObjects;

namespace GameServer
{
    public class GameLoop
    {
        private const double MaxValueAccum = 0.2;
        
        private const double DeltaTime = 1.0 / 60.0;
        
        public delegate void StepFinishedEventHandler(object sender, StepFinishedEventArgs args);
        
        public event StepFinishedEventHandler StepFinished;

        public void Execute()
        {
            var accumulator = 0.0;
            var frameStartTime = DateTime.Now;
            
            while (true)
            {
                var curTime = DateTime.Now;
                var elapsedMilliseconds = (curTime - frameStartTime).TotalMilliseconds;
                
                frameStartTime = curTime;
                
                accumulator +=  elapsedMilliseconds / 1000.0;

                if (accumulator > MaxValueAccum)
                    accumulator = MaxValueAccum;

                while (accumulator > DeltaTime)
                {
                    Scene.GetInstance.Update();
                    accumulator -= DeltaTime;
                }
                
                var state = Map.GetInstance.Checker.Check();
                if (state != GameState.Lose && Map.GetInstance.IsVictory)
                    state = GameState.Win;
                OnStepFinished(this, new StepFinishedEventArgs(accumulator/DeltaTime, elapsedMilliseconds, state));
            }
        }

        private void OnStepFinished(object sender, StepFinishedEventArgs args)
        {
            StepFinished?.Invoke(sender, args);
        }
    }
}