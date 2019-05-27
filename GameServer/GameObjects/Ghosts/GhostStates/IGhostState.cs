namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public interface IGhostState
    {
        void Move();
        
        GameObjectCode Code { get; }
    }
}