using System.Threading.Tasks;
using GameServer.GameMap;

namespace GameServer.GameObjects
{
    public delegate void PacManEatEventHandler(PacMan_EatEventArgs args);

    public class PacMan : IActor, IMovable
    {
        private const double Speed = 1.0 / 6.0;

        private double _elapsedSeconds;

        private bool _move;
        
        private static readonly PacMan Instance = new PacMan();

        public static PacMan GetInstance => Instance;
        
        public MoveDirection Direction { get; set; }
        
        public MapPoint Position { get; set; }

        public event MovedEventHandler Moved;
        
        public event PacManEatEventHandler AteSmth;

        private PacMan()
        {
            _elapsedSeconds = 0;
            _move = false;
        }

        public void OnAteSmth(PacMan_EatEventArgs args)
        {
            AteSmth?.Invoke(args);
        }
        
        private void OnMoved(IMovable sender, MovedEventArgs args)
        {
            Moved?.Invoke(sender, args);
        }
        
        public void Act()
        {
            if (!_move)
                return;
            
            OnMoved(this, new MovedEventArgs(Position[Direction]));
        }

        public void StepBack()
        {
            var dir = (int)(Direction + 2) % MapPoint.CountNeighbour;

            Position = Position[(MoveDirection) dir];
        }
        
        public void GameLoop_StepFinished(object sender, StepFinishedEventArgs args)
        {
            if (args.ElapsedMilliseconds / 1000.0 > Speed)
                _move = true;
            
            _elapsedSeconds += args.ElapsedMilliseconds / 1000.0;
        }
    }
}