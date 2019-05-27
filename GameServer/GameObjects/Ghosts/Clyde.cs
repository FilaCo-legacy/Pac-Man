namespace GameServer.GameObjects.Ghosts
{
    public class Clyde : Ghost
    {
        private static readonly Clyde Instance = new Clyde();

        public static Clyde GetInstance => Instance;
        
        public override GameObjectCode DefaultCode => GameObjectCode.Clyde;
    }
}