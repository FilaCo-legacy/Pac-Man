using GameServer.GameMap;

namespace GameServer.GameObjects
{
    public abstract class GameActor : IActor
    {
        private int _elapsedTicks;
        
        protected abstract int Ticks { get; }
        
        public MapPoint Position { get; set; }
        
        public MoveDirection Direction { get; set; }

        public GameActor()
        {
            _elapsedTicks = 0;
        }

        public void Act()
        {
            ++_elapsedTicks;

            if (_elapsedTicks < Ticks)
                return;

            Position = Position[Direction];
        }

        public void StepBack()
        {
            
        }
    }
}