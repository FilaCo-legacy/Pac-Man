namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class ChaseState:IGhostState
    {
        private const int TargetSeconds = 30;

        private const double Speed = 1.0 / 6.0;

        private readonly Ghost _ghost;

        private double _elapsedSeconds;

        private bool _move;
        
        private readonly Bfs _trajectoryCmp;
        
        public MoveDirection Direction { get; private set; }

        public ChaseState(Ghost ghost)
        {
            _ghost = ghost;
            ++_ghost.ScatterRepeats;

            _elapsedSeconds = 0;
            _move = true;
            _trajectoryCmp = new Bfs();
        }
        
        public void Act()
        {
            if (!_move)
                return;
            _move = false;

            Direction = _trajectoryCmp.Execute(_ghost.Position, _ghost.TargetChaseState);
        }
        
        public void PacMan_AteEnergizer()
        {
            _ghost.State = new FrightenedState(_ghost);
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