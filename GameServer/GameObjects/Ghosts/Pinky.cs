namespace GameServer.GameObjects.Ghosts
{
    public class Pinky : Ghost
    {
        private static readonly Pinky Instance = new Pinky();

        public static Pinky GetInstance => Instance;
        
        public override GameObjectCode DefaultCode => GameObjectCode.Pinky;
    }
}