using System.Collections.Generic;
using System.Diagnostics;
using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class ChaseState:IGhostState
    {
        private const int SecondsLength = 20;
        
        private readonly Ghost _ghost;
        
        private readonly Stopwatch _sw;
        
        public int Ticks => 10;

        public ChaseState(Ghost ghost)
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
            
            _ghost.State = new ScatterState(_ghost);

            if (direction == _ghost.Direction)
                direction = (MoveDirection)(((int)_ghost.Direction + 2) % MapPoint.CountNeighbour);
        }
        
        public MoveDirection ChooseDirection(MapPoint startPoint)
        {
            var targetPoint = _ghost.TargetPointChase;

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