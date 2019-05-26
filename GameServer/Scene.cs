using System.Collections.Generic;
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
        private static readonly Scene _instance = new Scene();

        public static Scene GetInstance => _instance;
        
        /// <summary>
        /// Collection of tasks of actors move-delegates
        /// </summary>
        private readonly ICollection <Task> _actorsMove;

        public Scene()
        {
            _actorsMove = new List<Task>
            {
                new Task(PacMan.GetInstance.Move),
                new Task(Blinky.GetInstance.Move),
                new Task(Inky.GetInstance.Move),
                new Task(Pinky.GetInstance.Move),
                new Task(Clyde.GetInstance.Move)
            };

        }

        /// <summary>
        /// Starts every actor move action and wait until all of them will end
        /// </summary>
        public async void StepAsync()
        {
            foreach (var curActorMove in _actorsMove)
            {
                curActorMove.Start();
            }

            await Task.WhenAll(_actorsMove);
        }
    }
}