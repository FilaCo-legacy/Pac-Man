using GameServer.GameObjects;

namespace GameServer
{
    public class StepFinishedEventArgs
    {
        public double Alpha { get; }

        public StepFinishedEventArgs(double alpha)
        {
            Alpha = alpha;
        }
    }
}