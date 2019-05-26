namespace GameServer
{
    public class Speedy : Ghost
    {
        private static readonly Speedy _instance = new Speedy();

        public static Speedy GetInstance => _instance;
    }
}