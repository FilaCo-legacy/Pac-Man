namespace GameServer.Ghosts
{
    public class Bashful : Ghost
    {
        private static readonly Bashful _instance = new Bashful();

        public static Bashful GetInstance => _instance;
    }
}