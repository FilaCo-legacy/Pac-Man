namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class ChaseState:IGhostState
    {

        public void Act()
        {
            throw new System.NotImplementedException();
        }

        public MoveDirection Direction { get; }
        
        public void PacMan_AteEnergizer()
        {
            throw new System.NotImplementedException();
        }

        public void GameLoop_StepFinished(object sender, StepFinishedEventArgs args)
        {
            throw new System.NotImplementedException();
        }
    }
}