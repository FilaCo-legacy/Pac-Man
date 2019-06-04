using System.Diagnostics;
using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class ScatterState : IGhostState
    {
        private const int SecondsLength = 7;

        private readonly Ghost _ghost;
        
        private readonly Stopwatch _sw;
        
        public int Ticks => 30;

        public int AnimateStates => 2;

        public ScatterState(Ghost ghost)
        {
            _ghost = ghost;
            
            _sw = new Stopwatch();
            _sw.Start();
        }
        
        private static bool CanMove(MapPoint targetPoint)
        {
            var map = Map.GetInstance;

            return targetPoint.IsValid(map) && map[targetPoint] != MapObjCode.Wall &&
                   map[targetPoint] != MapObjCode.Door;
        }

        private void CheckTimeElapsed(ref MoveDirection direction)
        {
            if (_sw.ElapsedMilliseconds / 1000 < SecondsLength)
                return;
            
            _ghost.State = new ChaseState(_ghost);
           
            if (direction == _ghost.Direction)
                direction = (MoveDirection)(((int)_ghost.Direction + 2) % MapPoint.CountNeighbour);
        }
        
        public MoveDirection ChooseDirection(MapPoint startPoint)
        {
            if (_ghost.TimesScatter >= Ghost.MaxTimesScatter)
            {
                _ghost.State = new ChaseState(_ghost);
                return _ghost.State.ChooseDirection(startPoint);
            }
            
            var targetPoint = _ghost.TargetPointScatter;

            var direction = MoveDirection.Left;
            var minDistance = 1e9;

            for (var curDir = 0; curDir < MapPoint.CountNeighbour; ++curDir)
            {
                var curNeighbour = startPoint[(MoveDirection) curDir];

                if (curNeighbour == _ghost.Position || !CanMove(curNeighbour) || 
                    (targetPoint - curNeighbour).LengthSquared >= minDistance)
                    continue;
                
                direction = (MoveDirection)curDir;
                minDistance = (targetPoint - curNeighbour).LengthSquared;
            }
            
            CheckTimeElapsed(ref direction);

            return direction;
        }
    }
}