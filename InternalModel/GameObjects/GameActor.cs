using System.Diagnostics;
using GameServer.GameMap;

namespace GameServer.GameObjects
{
    public abstract class GameActor : IActor
    {
        protected int _elapsedTicks;

        public abstract int Ticks { get; }
        
        public abstract int AnimateStates { get; }

        public MapPoint Position { get; set; }
        
        public int AnimateState { get; private set; }

        public virtual MoveDirection Direction { get; set; }

        protected virtual bool CanMove(MapPoint targetPoint)
        {
            var map = Map.GetInstance;

            return targetPoint.IsValid(map) && map[targetPoint] != MapObjCode.Wall;
        }

        public virtual void Act()
        {
            if (_elapsedTicks++ < Ticks)
                return;
            
            _elapsedTicks = 0;
            
            if (CanMove(Position[Direction]))
                Position = Position[Direction];

            AnimateState = (AnimateState+1) % AnimateStates;
        }
    }
}