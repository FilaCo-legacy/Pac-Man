namespace GameServer.GameObjects
{
    public abstract class GameObject
    {
        public IMapEntry MapEntry { get; set; }
        
        public abstract GameObjectCode Code { get; }
    }
}