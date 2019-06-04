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

        protected virtual bool CanMove(MapPoint targetPoint)
        {
            var map = Map.GetInstance;

            return targetPoint.IsValid(map) && map[targetPoint] != MapObjCode.Wall;
        }

        public virtual void Act()
        {
            ++_elapsedTicks;

            if (_elapsedTicks < Ticks)
                return;

            if (CanMove(Position[Direction]))
                Position = Position[Direction];
        }
    }
}