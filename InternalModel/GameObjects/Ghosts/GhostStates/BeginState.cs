using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class BeginState : IGhostState
    {
        private readonly Ghost _ghost;

        public int Ticks => 30;

        public int AnimateStates => 2;

        public BeginState(Ghost ghost)
        {
            _ghost = ghost;
        }

        private static bool CanMove(MapPoint targetPoint)
        {
            var map = Map.GetInstance;

            return targetPoint.IsValid(map) && map[targetPoint] != MapObjCode.Wall;
        }
        
        public MoveDirection ChooseDirection(MapPoint startPoint)
        {
            var targetPoint = Ghost.TargetBeginPoint;

            if (startPoint == targetPoint)
            {
                _ghost.State = new ScatterState(_ghost);
                return MoveDirection.Left;
            }

            var direction = MoveDirection.Left;
            var minDistance = 1e9;

            for (var curDir = 0; curDir < MapPoint.CountNeighbour; ++curDir)
            {
                var curNeighbour = startPoint[(MoveDirection) curDir];

                if (curNeighbour == _ghost.Position || !CanMove(curNeighbour) ||
                    (targetPoint - curNeighbour).LengthSquared >= minDistance)
                    continue;

                direction = (MoveDirection) curDir;
                minDistance = (targetPoint - curNeighbour).LengthSquared;
            }

            return direction;
        }
    }
}