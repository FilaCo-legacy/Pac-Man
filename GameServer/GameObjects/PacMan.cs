using System.Threading.Tasks;
using GameServer.GameMap;

namespace GameServer.GameObjects
{
    public delegate void PacManEatEventHandler(PacMan_EatEventArgs args);

    public class PacMan : IActor
    {
        private const double Speed = 1.0 / 6.0;

        private double _elapsedSeconds;

        private bool _move;
        
        private static readonly PacMan Instance = new PacMan();

        public static PacMan GetInstance => Instance;
        
        public MoveDirection Direction { get; set; }
        
        public MapPoint Position { get; set; }

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

        public void Act()
        {
        }
    }
}