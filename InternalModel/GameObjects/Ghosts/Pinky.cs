using System;
using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts
{
    public class Pinky : Ghost
    {
        private static readonly Pinky Instance = new Pinky();

        public static Pinky GetInstance => Instance;

        public override MapPoint TargetPointScatter => new MapPoint(0, 2);

        public override MapPoint TargetPointChase
        {
            get
            {
                var targetPos = PacMan.GetInstance.Position;

                for (var i = 0; i < 4; ++i)
                    targetPos = targetPos[PacMan.GetInstance.Direction];

                return targetPos;
            }
        }

        private Pinky()
        {

        }
    }
}