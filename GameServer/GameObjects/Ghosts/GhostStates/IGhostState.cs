namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public abstract class GhostState
    {
        void Move();
        
        GameObjectCode Code { get; }

        void CollideWith(PacMan pacMan);
    }
}