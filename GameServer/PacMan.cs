namespace GameServer
{
    public class PacMan : GameObject
    {
        private static readonly PacMan _instance = new PacMan();

        public static PacMan GetInstance => _instance;
        
        
    }
}