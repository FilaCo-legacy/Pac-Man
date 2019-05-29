namespace GameServer.GameObjects
{
    public class PacMan_EatEventArgs
    {
        public GameObjectCode EatenObject { get; }

        public PacMan_EatEventArgs(GameObjectCode eatenObject) => EatenObject = eatenObject;
    }
}