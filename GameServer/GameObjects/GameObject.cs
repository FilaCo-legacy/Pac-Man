namespace GameServer.GameObjects
{
    public enum GameObjectCode
    {
        Void,
        Food,
        Energizer,
        Fruit,
        Wall,
        Pac_Man,
        Blinky,
        Clyde,
        Inky,
        Pinky,
        Ghost_Frightened
    }
    public abstract class GameObject
    {
        public IMapEntry MapEntry { get; set; }
        
        public abstract GameObjectCode Code { get; }
    }
}