namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public interface IGhostState
    {
        void Act();
        
        MoveDirection Direction { get; }
        

        void OnPacManAteSmth(PacMan_EatEventArgs args);

        void GameLoop_StepFinished(object sender, StepFinishedEventArgs args);
    }
}