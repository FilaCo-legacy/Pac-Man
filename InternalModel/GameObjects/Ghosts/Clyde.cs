using System;
using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts
{
    public class Clyde:Ghost
    {
        private static readonly Clyde Instance = new Clyde();

        public static Clyde GetInstance => Instance;
        
        public override MapPoint TargetPointScatter => new MapPoint(35, 0);

        public override MapPoint TargetPointChase
        {
            get
            {
                var pacManPos = PacMan.GetInstance.Position;

                return Math.Sqrt((Position - pacManPos).LengthSquared) < 8 ? TargetPointScatter : pacManPos;
            }
        }

        private Clyde()
        {
            Position = new MapPoint(17, 14);
        }
    }
}