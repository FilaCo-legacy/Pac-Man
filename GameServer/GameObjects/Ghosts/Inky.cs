namespace GameServer.GameObjects.Ghosts
{
    public class Inky : Ghost
    {
        private static readonly Inky Instance = new Inky();

        public static Inky GetInstance => Instance;
    }
}