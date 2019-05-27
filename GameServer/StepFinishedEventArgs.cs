using GameServer.GameObjects;

namespace GameServer
{
    public class StepFinishedEventArgs
    {
        public float Alpha { get; }
        
        public Map GameMap { get; }

        public StepFinishedEventArgs(float alpha)
        {
            Alpha = alpha;
        }
    }
}