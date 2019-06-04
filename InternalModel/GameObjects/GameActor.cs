using System.Diagnostics;
using GameServer.GameMap;

namespace GameServer.GameObjects
{
    public abstract class GameActor : IActor
    {
        private readonly Stopwatch _sw;

        protected abstract int MillisecondsSkip { get; }

        public MapPoint Position { get; set; }

        public virtual MoveDirection Direction { get; set; }

        public GameActor()
        {
            _sw = new Stopwatch();
            _sw.Start();
        }

        protected virtual bool CanMove(MapPoint targetPoint)
        {
            var map = Map.GetInstance;

            return targetPoint.IsValid(map) && map[targetPoint] != MapObjCode.Wall;
        }

        public virtual void Act()
        {
            if (_sw.ElapsedMilliseconds < MillisecondsSkip)
                return;
            
            if (CanMove(Position[Direction]))
                Position = Position[Direction];
            
            _sw.Restart();
        }
    }
}