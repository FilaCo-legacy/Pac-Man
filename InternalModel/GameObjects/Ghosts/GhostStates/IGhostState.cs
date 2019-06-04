namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public interface IGhostState
    {
        MoveDirection ChooseDirection();
        
        int Ticks { get; }
    }
}