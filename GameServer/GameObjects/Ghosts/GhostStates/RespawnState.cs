using System;

namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class RespawnState : IGhostState
    {
        private static readonly Random Rnd = new Random();

        private const double Speed = 1.0 / 9.0;

        private bool _move;

        private readonly Ghost _ghost;

        private readonly MapPoint _destPnt;

        private readonly Bfs _trajectoryCmp;
        
        public void Act()
        {
            if (!_move)
                return;
            _move = false;

            Direction = _trajectoryCmp.Execute(_ghost.Position, _destPnt);
        }

        public MoveDirection Direction { get; private set; }

        public RespawnState(Ghost ghost)
        {
            _ghost = ghost;
            _move = false;
            _destPnt = new MapPoint
            {
                Row = Map.LeftUpperGhostRoom.Row + Rnd.Next(0, Map.GhostRoomWidth + 1), 
                Column = Map.LeftUpperGhostRoom.Column + Rnd.Next(0, Map.GhostRoomHeight + 1)
            };
            _trajectoryCmp = new Bfs();
        }

        public void PacMan_AteEnergizer() {}

        public void GameLoop_StepFinished(object sender, StepFinishedEventArgs args)
        {
            if (args.ElapsedMilliseconds / 1000.0 > Speed)
                _move = true;
            
            if (_ghost.Position == _destPnt)
                _ghost.State = new ScatterState();
        }
    }
}