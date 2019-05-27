namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class RespawnState : IGhostState
    {
        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public GameObjectCode Code { get; }
        
        public void CollideWith(PacMan pacMan)
        {
            throw new System.NotImplementedException();
        }
    }
}