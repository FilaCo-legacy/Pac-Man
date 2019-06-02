using System;
using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class RespawnState : IGhostState
    {
        public void Act()
        {
            throw new NotImplementedException();
        }

        public MoveDirection Direction { get; }
        public void OnPacManAteSmth(PacMan_EatEventArgs args)
        {
            throw new NotImplementedException();
        }

        public void GameLoop_StepFinished(object sender, StepFinishedEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}