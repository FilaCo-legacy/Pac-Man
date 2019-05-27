using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameServer.GameObjects;
using GameServer.GameObjects.Ghosts;

namespace GameServer
{
    /// <summary>
    /// Makes all movable game objects to move async.
    /// It is an implementation of the Singletone Pattern
    /// </summary>
    public class Scene
    {
        /// <summary>
        /// Collection of actors
        /// </summary>
        private readonly ICollection <MovableGameObject> _actors;
        
        public Map SceneMap { get; }

        public Scene(Map sceneMap)
        {
            _actors = new List<MovableGameObject>
            {
                new PacMan(),
                new Blinky(),
                new Clyde(),
                new Inky(),
                new Pinky()
            };

            SceneMap = sceneMap;
        }

        /// <summary>
        /// Starts every actor move action and wait until all of them will end
        /// </summary>
        public void Update()
        {
            var actorsMove = new List<Task>();
            
            actorsMove.AddRange(_actors.Select(curActor => Task.Run(curActor.Move)));

            Task.WhenAll(actorsMove).Wait();
        }
    }
}