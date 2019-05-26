namespace GameServer.GameObjects.Ghosts
{
    public class Inky : Ghost
    {
        private static readonly Inky _instance = new Inky();

        public static Inky GetInstance => _instance;
    }
}