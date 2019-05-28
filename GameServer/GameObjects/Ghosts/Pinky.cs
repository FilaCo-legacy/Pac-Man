using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts
{
    public class Pinky : Ghost
    {
        private static readonly Pinky Instance = new Pinky();

        public static Pinky GetInstance => Instance;
        public override MapPoint TargetScatterState =>new MapPoint(3 ,3 );

        public override MapPoint TargetChaseState
        {
            get
            {
                var targetPnt = PacMan.GetInstance.Position;
                var pacManDir = PacMan.GetInstance.Direction;

                for (var i = 0; i < 4; ++i)
                {
                    targetPnt = targetPnt[pacManDir];
                }

                return targetPnt;
            }
        }
    }
}