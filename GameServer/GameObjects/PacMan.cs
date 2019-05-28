using System.Threading.Tasks;
using GameServer.GameMap;

namespace GameServer.GameObjects
{
    public class PacMan : IActor, IMovable
    {
        private static readonly PacMan Instance = new PacMan();

        public static PacMan GetInstance => Instance;

        public MoveDirection Direction { get; set; }
        
        public MapPoint Position { get; set; }

        public event MovedEventHandler Moved;

        private void OnMoved(IMovable sender, MovedEventArgs args)
        {
            Task.Run(() => Moved?.Invoke(sender, args));
        }
        
        public void Act()
        {
            OnMoved(this, new MovedEventArgs(GameObjectCode.PacMan));
        }
    }
}