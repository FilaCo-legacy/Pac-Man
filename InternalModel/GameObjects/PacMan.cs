
using GameServer.GameMap;

namespace GameServer.GameObjects
{
    public class PacMan : GameActor
    {
        private static readonly PacMan Instance = new PacMan();

        private MoveDirection _direction;

        private MoveDirection _requestDirection;
        
        public static PacMan GetInstance => Instance;
        
        protected override int MillisecondsSkip => 150;

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
        }
        
        protected override bool CanMove(MapPoint targetPoint)
        {
            return base.CanMove(targetPoint) && Map.GetInstance[targetPoint] != MapObjCode.Door;
        }
    }
}