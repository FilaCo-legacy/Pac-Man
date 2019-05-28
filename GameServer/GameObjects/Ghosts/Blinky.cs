namespace GameServer.GameObjects.Ghosts
{
    public class Blinky : Ghost
    {
        private static readonly Blinky Instance = new Blinky();

        public static Blinky GetInstance => Instance;
        public override MapPoint TargetScatterState { get; }
        public override MapPoint TargetChaseState { get; }
    }
}