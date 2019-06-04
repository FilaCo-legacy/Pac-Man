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

        protected virtual bool CanMove(MapObjCode targetEntry)
        {
            return targetEntry != MapObjCode.Wall;
        }

        public virtual void Act()
        {
            ++_elapsedTicks;

            if (_elapsedTicks < Ticks)
                return;

            if (CanMove(Map.GetInstance[Position[Direction]]))
                Position = Position[Direction];
        }
    }
}