namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public interface IGhostState
    {
        void Act();
        
        MoveDirection Direction { get; }
    }
}