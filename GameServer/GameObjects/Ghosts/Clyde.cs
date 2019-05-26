namespace GameServer.GameObjects.Ghosts
{
    public class Clyde : Ghost
    {
        private static readonly Clyde _instance = new Clyde();

        public static Clyde GetInstance => _instance;
    }
}