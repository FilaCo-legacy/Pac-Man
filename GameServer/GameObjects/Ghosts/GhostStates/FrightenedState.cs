using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class FrightenedState : IGhostState
    {
        private const int TargetSeconds = 10;

        private const double Speed = 1.0 / 3.0;
        
        private static readonly Random Rnd = new Random();

        private readonly Ghost _ghost;

        private double _elapsedSeconds;

        private bool _move;
        
        public MoveDirection Direction { get; private set; }

        public FrightenedState(Ghost ghost)
        {
            Direction = _ghost.Direction;
            _elapsedSeconds = 0;
            _ghost = ghost;
            _move = false;
        }
        
        public void Act()
        {
            if (!_move)
                return;
            _move = true;

            var direction = (int) Direction;
            var posDir = new List<MoveDirection>();

            for (var shift = -1; shift <= 1; ++shift)
            {
                var curDir = Math.Abs(direction + shift) % MapPoint.CountNeighbour;

                var targetMapPnt = _ghost.Position[(MoveDirection) curDir];

                if (targetMapPnt.IsValid && Map.GetInstance[targetMapPnt].Peek() != GameObjectCode.Wall)
                    posDir.Add((MoveDirection)curDir);
            }

            if (posDir.Count > 0)
                Direction = posDir[Rnd.Next(0, posDir.Count)];
            else
            {
                var backDir = (direction + 2) % MapPoint.CountNeighbour;
                Direction = (MoveDirection)backDir;
            }

            _ghost.OnMoved(_ghost, new MovedEventArgs(GameObjectCode.Ghost));
        }
        
        public void PacMan_AteEnergizer()
        {
            _elapsedSeconds = 0;
        }

        public void GameLoop_StepFinished(object sender, StepFinishedEventArgs args)
        {
            if (args.ElapsedMilliseconds / 1000.0 > Speed)
                _move = true;
            
            _elapsedSeconds += args.ElapsedMilliseconds / 1000.0;

            if (_elapsedSeconds >= TargetSeconds)
                _ghost.State = new ScatterState(_ghost);
        }
    }
}