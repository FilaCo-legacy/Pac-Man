using System.Threading;
using System.Threading.Tasks;

namespace GameServer.GameObjects.Ghosts
{
    public abstract class Ghost : GameObject, IMovable
    {
        private readonly Thread _thread;
        
        public IGhostState State { get; set; }
        
        public MoveDirection Direction { get; set; }

        protected Ghost()
        {
            
        }
        
        public void Move() => State.Move();

        public async void MoveAsync() => await Task.Run(Move);
    }
}