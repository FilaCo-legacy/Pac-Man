namespace GameServer.GameObjects
{
    public class PacMan_EatEventArgs
    {
        public MapObjCode EatenObject { get; }

        public PacMan_EatEventArgs(MapObjCode eatenObject) => EatenObject = eatenObject;
    }
}