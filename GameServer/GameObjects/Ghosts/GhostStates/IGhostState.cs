namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public interface IGhostState
    {
        void Act();
        
        MoveDirection Direction { get; }

        void GameLoop_StepFinished(object sender, StepFinishedEventArgs args);
    }
}