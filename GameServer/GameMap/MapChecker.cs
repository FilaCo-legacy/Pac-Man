using System.Collections.Generic;
using GameServer.GameObjects;
using GameServer.GameObjects.Ghosts;

namespace GameServer.GameMap
{
    public class MapChecker
    {
        private static GameState CheckGhosts()
        {
            var ghostsList = new List<Ghost>
                {Blinky.GetInstance, Inky.GetInstance, Pinky.GetInstance, Clyde.GetInstance};

            foreach (var curGhost in ghostsList)
            {
                var ghostReact = OnPacManReaction.None;
                if (curGhost.Position == PacMan.GetInstance.Position)
                    ghostReact = curGhost.ReactOnPacMan;

                if (ghostReact == OnPacManReaction.Eat)
                {
                    return GameState.Lose;
                }
                else if (ghostReact == OnPacManReaction.Eaten)
                {
                    PacMan.GetInstance.OnAteSmth(new PacMan_EatEventArgs(GameObjectCode.Ghost));
                }
            }

            return GameState.GoingOn;
        }

        private static void CheckPacMan()
        {
            var content = Map.GetInstance[PacMan.GetInstance.Position];

            switch (content)
            {
                case GameObjectCode.Door:
                    PacMan.GetInstance.StepBack();
                    break;
                case GameObjectCode.Energizer:
                case GameObjectCode.Food:
                    PacMan.GetInstance.OnAteSmth(new PacMan_EatEventArgs(content));
                    break;
            }
        }
        
        public GameState Check()
        {
            var state = CheckGhosts();
            
            CheckPacMan();

            return state;
        }
    }
}