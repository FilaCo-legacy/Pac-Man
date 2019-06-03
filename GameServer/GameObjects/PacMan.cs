using GameServer.GameMap;

namespace GameServer.GameObjects
{
    public class PacMan : IActor
    {
        private const int Ticks = 6;
        
        private static readonly PacMan _instance = new PacMan();

        public static PacMan GetInstance => _instance;

        public int ElapsedTicks { get; private set; }

        public MoveDirection Direction { get; set; }
        
        public MapPoint Position { get; set; }

        private PacMan()
        {
            Position = Map.GetInstance.StartPacManLocation;
            ElapsedTicks = 0;
        }

        public void Act()
        {
            ++ElapsedTicks;

            if (ElapsedTicks < Ticks) return;
            
            Position = Position[Direction];
            ElapsedTicks = 0;
        }
    }
}