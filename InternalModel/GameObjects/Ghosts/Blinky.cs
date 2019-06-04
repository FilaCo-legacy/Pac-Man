using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts
{
    public class Blinky:Ghost
    {
        private static readonly Blinky Instance = new Blinky();

        public static Blinky GetInstance => Instance;
        
        public override MapPoint TargetPointScatter => new MapPoint(0, 26);

        public override MapPoint TargetPointChase => PacMan.GetInstance.Position;

        private Blinky()
        {
            Position = new MapPoint(15, 13);
        }
    }
}