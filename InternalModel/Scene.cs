using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameServer.GameObjects;

namespace GameServer
{
    /// <summary>
    /// Makes all movable game objects to move async.
    /// </summary>
    public class Scene : IScene
    {
        /// <summary>
        /// Collection of actors
        /// </summary>
        private readonly ICollection <IActor> _actors;

        public Scene()
        {
            _actors = new List<IActor>{PacMan.GetInstance};
        }

        /// <summary>
        /// Starts every actor move action and wait until all of them will end
        /// </summary>
        public void Update()
        {
            var actorsMove = new List<Task>();
            
            actorsMove.AddRange(_actors.Select(curActor => Task.Run(curActor.Act)));

            Task.WhenAll(actorsMove).Wait();
        }

        public void Add(IActor actor)
        {
            _actors.Add(actor);
        }
    }
}