using System.Collections.Generic;
using GameServer.GameMap;
using GameServer.GameObjects.Ghosts;
using GameServer.GameObjects.Ghosts.GhostStates;

namespace GameServer.GameObjects
{
    public class ActorsChecker : IActorsChecker
    {
        private List<Ghost> _ghosts = new List<Ghost> {Blinky.GetInstance, Inky.GetInstance, Pinky.GetInstance, Clyde.GetInstance};
        
        private void ScareGhosts()
        {
            foreach (var ghost in _ghosts)
            {
                ghost.State = new FrightenedState(ghost);
            }
        }

        private void CheckPacMan()
        {
            var pacMan = PacMan.GetInstance;
            var map = Map.GetInstance;

            switch (map[pacMan.Position])
            {
                case MapObjCode.Energizer:
                    map[pacMan.Position] = MapObjCode.Void;
                    ScareGhosts();
                    break;
                case MapObjCode.Food:
                    map[pacMan.Position] = MapObjCode.Void;
                    break;
            }
        }
        
        public void Check()
        {
            CheckPacMan();
        }
    }
}