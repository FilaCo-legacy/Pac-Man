using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts
{
    public class Inky : Ghost
    {
        private static readonly Inky Instance = new Inky();

        public static Inky GetInstance => Instance;
        
        public override MapPoint TargetScatterState=> new MapPoint(27 ,20 );

        public override MapPoint TargetChaseState
        {
            get
            {
                var blinkyPos = Blinky.GetInstance.Position;

                var segmentMid = PacMan.GetInstance.Position;
                var pacManDir = PacMan.GetInstance.Direction;

                for (var i = 0; i < 2; ++i)
                    segmentMid = segmentMid[pacManDir];

                return segmentMid + (segmentMid - blinkyPos);
            }
        }
    }
}