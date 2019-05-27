namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class FrightenedState : IGhostState
    {
        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public GameObjectCode Code => GameObjectCode.Ghost_Frightened;
    }
}