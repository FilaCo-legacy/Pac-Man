namespace GameServer
{
    public class Pockey : Ghost
    {
        private static readonly Pockey _instance = new Pockey();

        public static Pockey GetInstance => _instance;
    }
}