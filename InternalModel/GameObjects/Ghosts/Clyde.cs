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

                if (Math.Sqrt((Position - pacManPos).LengthSquared) < 8)
                    return TargetPointScatter;

                return pacManPos;
            }
        }

        private Clyde()
        {
            
        }
    }
}