
using GameServer.GameMap;

namespace GameServer.GameObjects
{
    public class PacMan : GameActor
    {
        private const int States = 4;
        
        private static readonly PacMan Instance = new PacMan();
        public static PacMan GetInstance => Instance;
        
        private MoveDirection _direction;

        private MoveDirection _requestDirection;
        
        public override int Ticks => 30;
        
        public int State { get; private set; }

        public override MoveDirection Direction
        {
            get => CanMove(Position[_requestDirection]) ? _direction = _requestDirection : _direction;
            set
            {
                if (CanMove(Position[value]))
                    _direction = value;

                _requestDirection = value;
            }
        }

        private PacMan()
        {
            Position = Map.GetInstance.StartPacManLocation;
            State = 0;
        }
        
        protected override bool CanMove(MapPoint targetPoint)
        {
            return base.CanMove(targetPoint) && Map.GetInstance[targetPoint] != MapObjCode.Door;
        }

        public override void Act()
        {
            if (ElapsedTicks == Ticks)
                State = (State + 1) % States;
            base.Act();
        }
    }
}