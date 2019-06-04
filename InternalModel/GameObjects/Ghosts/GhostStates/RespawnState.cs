using System;
using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class RespawnState : IGhostState
    {
        public int Ticks => 5;

        public MoveDirection ChooseDirection(MapPoint startPoint)
        {
            throw new NotImplementedException();
        }

        
    }
}