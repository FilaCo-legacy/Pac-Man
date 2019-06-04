using System;
using GameServer.GameMap;

namespace GameServer.GameObjects
{
    public class PacMan : IActor
    {
        private const int Ticks = 10;
        
        private static readonly PacMan Instance = new PacMan();

        public static PacMan GetInstance => Instance;

        public MoveDirection Direction { get; set; }
        
        public MapPoint Position { get; set; }
        
        public int ElapsedTicks { get; set; }

        private PacMan()
        {
            Position = Map.GetInstance.StartPacManLocation;
        }

        public void Act()
        {
            ++ElapsedTicks;
            
            if (ElapsedTicks < Ticks)
                return;
            
            var map = Map.GetInstance;

            ElapsedTicks = 0;
            
            if (map[Position[Direction]] != MapObjCode.Wall && map[Position[Direction]] != MapObjCode.Door)
                Position = Position[Direction];
        }
    }
}