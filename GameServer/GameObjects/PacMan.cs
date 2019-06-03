using GameServer.GameMap;

namespace GameServer.GameObjects
{
    public class PacMan : IActor
    {
        private static readonly PacMan Instance = new PacMan();

        public static PacMan GetInstance => Instance;

        public MoveDirection Direction { get; set; }
        
        public MapPoint Position { get; set; }

        private PacMan()
        {
            Position = Map.GetInstance.StartPacManLocation;
        }

        public void Act()
        {
            var map = Map.GetInstance;
            if (map[Position[Direction]] != MapObjCode.Wall && map[Position[Direction]] != MapObjCode.Door)
                Position = Position[Direction];
        }
    }
}