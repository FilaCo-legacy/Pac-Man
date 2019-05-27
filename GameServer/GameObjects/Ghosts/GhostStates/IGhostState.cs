namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public interface IGhostState
    {
        void Move();
        
        GameObjectCode Code { get; }

        void CollideWith(PacMan pacMan);
    }
}