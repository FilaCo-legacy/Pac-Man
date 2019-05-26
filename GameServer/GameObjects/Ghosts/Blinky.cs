namespace GameServer.GameObjects.Ghosts
{
    public class Blinky : Ghost
    {
        private static readonly Blinky _instance = new Blinky();

        public static Blinky GetInstance => _instance;
    }
}