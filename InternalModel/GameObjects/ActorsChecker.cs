using System.Collections.Generic;
using GameServer.GameMap;
using GameServer.GameObjects.Ghosts;
using GameServer.GameObjects.Ghosts.GhostStates;

namespace GameServer.GameObjects
{
    public class ActorsChecker : IActorsChecker
    {
        private List<Ghost> _ghosts = new List<Ghost> {Blinky.GetInstance, Inky.GetInstance, Pinky.GetInstance, Clyde.GetInstance};
        

        private int _food;

        public ActorsChecker(int food)
        {
            _food = food;
        }
        
        private void ScareGhosts()
        {
            foreach (var ghost in _ghosts)
            {
                ghost.State = new FrightenedState(ghost);
            }
        }

        private GameState GhostsCheck()
        {
            foreach (var ghost in _ghosts)
            {
                if (ghost.Position == PacMan.GetInstance.Position)
                {
                    if (ghost.State is FrightenedState)
                        ghost.State = new RespawnState(ghost);
                    else if (! (ghost.State is RespawnState))
                    {
                        return GameState.Lose;
                    }
                }
            }

            return GameState.OnGoing;
        }
        
        private GameState CheckPacMan()
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
                    --_food;
                    map[pacMan.Position] = MapObjCode.Void;
                    break;
            }

            return _food == 0 ? GameState.Win : GameState.OnGoing;
        }
        
        public GameState Check()
        {
            var answer = GameState.OnGoing;
            
            answer = CheckPacMan();

            if (answer != GameState.Win)
                return GhostsCheck();

            return answer;
        }
    }
}