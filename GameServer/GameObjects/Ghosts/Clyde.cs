namespace GameServer.GameObjects.Ghosts
{
    public class Clyde : Ghost
    {
        private static readonly Clyde Instance = new Clyde();

        public static Clyde GetInstance => Instance;
        public override MapPoint TargetScatterState { get; }
        public override MapPoint TargetChaseState { get; }
    }
}