using GameServer.GameObjects;

namespace GameServer
{
    public class StepFinishedEventArgs
    {
        public double Alpha { get; }
        
        public double ElapsedMilliseconds { get; }
        
        public GameState GameState { get; }

        public StepFinishedEventArgs(double alpha, double elapsedMilliseconds, GameState gameState)
        {
            Alpha = alpha;
            ElapsedMilliseconds = elapsedMilliseconds;
            GameState = gameState;
        }
    }
}