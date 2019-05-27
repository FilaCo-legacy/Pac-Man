using System.Diagnostics;

namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class FrightenedState : IGhostState
    {
        private Stopwatch _sw;

        private Ghost _ghost;
        
        public GameObjectCode Code => GameObjectCode.Ghost_Frightened;
        
        public void Move()
        {
            
        }

        public FrightenedState(Ghost ghost)
        {
            _sw = new Stopwatch();
            _ghost = ghost;
            
            _sw.Start();
        }
    }
}