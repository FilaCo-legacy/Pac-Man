namespace GameServer
{
    public class Shadow : Ghost
    {
        private static readonly Shadow _instance = new Shadow();

        public static Shadow GetInstance => _instance;
    }
}