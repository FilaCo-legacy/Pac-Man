using System;
using System.Collections.Generic;
using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class FrightenedState : IGhostState
    {
        private static readonly Random Rnd = new Random();

        private readonly Ghost _ghost;

        public int Ticks => 15;

        public FrightenedState(Ghost ghost)
        {
            _ghost = ghost;
        }

        private static bool CanMove(MapPoint targetPoint)
        {
            var map = Map.GetInstance;

            return targetPoint.IsValid(map) && map[targetPoint] != MapObjCode.Wall &&
                   map[targetPoint] != MapObjCode.Door;
        }

        public MoveDirection ChooseDirection()
        {
            var nextPoint = _ghost.Position[_ghost.Direction];

            var possibleDirections = new List<MoveDirection>();

            for (var dir = 0; dir < MapPoint.CountNeighbour; ++dir)
            {
                var curNeighbour = nextPoint[(MoveDirection) dir];

                if (curNeighbour != _ghost.Position && CanMove(curNeighbour))
                    possibleDirections.Add((MoveDirection) dir);
            }

            return possibleDirections[Rnd.Next(0, possibleDirections.Count)];
        }
    }
}