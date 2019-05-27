namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public abstract class ScatterState : IGhostState
    {
        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public abstract GameObjectCode Code { get; }
        
        public void CollideWith(PacMan pacMan)
        {
            throw new System.NotImplementedException();
        }
    }
}