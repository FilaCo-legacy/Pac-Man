using System.Collections.Generic;
using System.Diagnostics;
using GameServer.GameObjects;
using GameServer.GameObjects.Ghosts;
using NLog;

namespace GameServer
{
    public class Scene
    {
        private static readonly Scene _instance = new Scene();

        public static Scene GetInstance => _instance;
        
        private readonly ICollection <IMovable> _actors;

        public Scene()
        {
            _actors = new List<IMovable>
            {
                PacMan.GetInstance,
                Blinky.GetInstance,
                Inky.GetInstance,
                Pinky.GetInstance,
                Clyde.GetInstance
            };

        }

        public void Step()
        {
            foreach (var curActor in _actors)
            {
                curActor.MoveAsync();
            }
        }
    }
}