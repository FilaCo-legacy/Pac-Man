using GameServer.GameObjects;

namespace GameServer
{
    public class StepFinishedEventArgs
    {
        public double Alpha { get; }
        
        public double ElapsedMilliseconds { get; }

        public StepFinishedEventArgs(double alpha, double elapsedMilliseconds)
        {
            Alpha = alpha;
            ElapsedMilliseconds = elapsedMilliseconds;
        }
    }
}