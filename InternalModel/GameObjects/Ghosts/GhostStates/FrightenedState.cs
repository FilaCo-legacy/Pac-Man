using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class FrightenedState : IGhostState
    {
        private static readonly Random Rnd = new Random();

        private const int SecondsLength = 10;

        private readonly Ghost _ghost;

        private readonly Stopwatch _sw;

        public int Ticks => 60;

        public int AnimateStates => 2;

        public FrightenedState(Ghost ghost)
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

        private void CheckTimeElapsed()
        {
            if (_sw.ElapsedMilliseconds / 1000 < SecondsLength)
                return;
            
            _ghost.State = new ChaseState(_ghost);
        }

        public MoveDirection ChooseDirection(MapPoint startPoint)
        {
            var possibleDirections = new List<MoveDirection>();

            for (var dir = 0; dir < MapPoint.CountNeighbour; ++dir)
            {
                var curNeighbour = startPoint[(MoveDirection) dir];

                if (curNeighbour != _ghost.Position && CanMove(curNeighbour))
                    possibleDirections.Add((MoveDirection) dir);
            }
            
            CheckTimeElapsed();
            
            return possibleDirections[Rnd.Next(0, possibleDirections.Count)];
        }
    }
}