using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts
{
    public class Clyde : Ghost
    {
        private static readonly Clyde Instance = new Clyde();

        public static Clyde GetInstance => Instance;

        private readonly Bfs _lengthComputer;

        private Clyde()
        {
            _lengthComputer = new Bfs();
        }
        
        public override MapPoint TargetScatterState => new MapPoint(27 ,7 );

        public override MapPoint TargetChaseState =>
            _lengthComputer.Distance(Position, PacMan.GetInstance.Position) > 8 ?
                PacMan.GetInstance.Position : TargetScatterState;
    }
}