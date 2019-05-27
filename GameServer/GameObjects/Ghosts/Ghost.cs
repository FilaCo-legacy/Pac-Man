using System.Data;
using GameServer.GameObjects.Ghosts.GhostStates;

namespace GameServer.GameObjects.Ghosts
{
    public abstract class Ghost : IActor, IMovable
    {
        public IGhostState State { get; set; }

        protected Ghost()
        {
        }

        private void OnMoved(IMovable sender, MovedEventArgs args)
        {
            Moved?.BeginInvoke(sender, args,null, null);
        }

        public void Act()
        {
            State.Act();
            OnMoved(this, new MovedEventArgs(GameObjectCode.Ghost));
        }

        public MoveDirection Direction => State.Direction;
        
        public int Row { get; set; }
        
        public int Column { get; set; }
        
        public event MovedEventHandler Moved;
    }
}