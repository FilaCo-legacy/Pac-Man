using System;
using System.Threading.Tasks;
using GameServer.GameObjects.Ghosts;

namespace GameServer.GameObjects
{
    public class PacMan : IActor, IMovable
    {
        private static readonly PacMan Instance = new PacMan();

        public static PacMan GetInstance => Instance;

        public MoveDirection Direction { get; }
        
        public int Row { get; set; }
        
        public int Column { get; set; }
        
        public event MovedEventHandler Moved;

        private void OnMoved(IMovable sender, MovedEventArgs args)
        {
            Moved?.BeginInvoke(sender, args,null, null);
        }
        
        public void Act()
        {
            throw new NotImplementedException();
            
            OnMoved(this, new MovedEventArgs(GameObjectCode.PacMan));
        }
    }
}