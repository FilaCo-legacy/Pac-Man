namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public abstract class ChaseState:IGhostState
    {
        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public GameObjectCode Code { get; }
    }
}