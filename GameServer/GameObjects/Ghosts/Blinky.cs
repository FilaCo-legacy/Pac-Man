using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts
{
    public class Blinky : Ghost
    {
        private static readonly Blinky Instance = new Blinky();

        public static Blinky GetInstance => Instance;
        public override MapPoint TargetScatterState => new MapPoint(3 ,24 );
        public override MapPoint TargetChaseState => PacMan.GetInstance.Position;
    }
}