using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class FrightenedState : IGhostState
    {
        public void Act()
        {
            throw new NotImplementedException();
        }

        public MoveDirection Direction { get; }

        public void GameLoop_StepFinished(object sender, StepFinishedEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}