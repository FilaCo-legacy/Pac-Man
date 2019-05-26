namespace GameServer.GameObjects.Ghosts
{
    public class Pinky : Ghost
    {
        private static readonly Pinky _instance = new Pinky();

        public static Pinky GetInstance => _instance;
    }
}