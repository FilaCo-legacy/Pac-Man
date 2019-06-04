
using GameServer.GameMap;

namespace GameServer.GameObjects
{
    public class PacMan : GameActor
    {
        private static readonly PacMan Instance = new PacMan();

        public static PacMan GetInstance => Instance;
        
        protected override int Ticks => 10;
        
        protected override bool CanMove(MapPoint targetPoint)
        {
            return base.CanMove(targetPoint) && Map.GetInstance[targetPoint] != MapObjCode.Door;
        }

        private PacMan(){}
    }
}