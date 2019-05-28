using System.Threading.Tasks;
using GameServer.GameMap;
using GameServer.GameObjects.Ghosts.GhostStates;

namespace GameServer.GameObjects.Ghosts
{
    public abstract class Ghost : IActor, IMovable
    {
        public int ScatterRepeats { get; set; }
        
        public IGhostState State { private get; set; }
        
        public MoveDirection Direction => State.Direction;
        
        public MapPoint Position { get; set; }
        
        public abstract MapPoint TargetScatterState { get; }
        
        public abstract MapPoint TargetChaseState { get; }

        public event MovedEventHandler Moved;

        public void PacMan_AteEnergizer() => State.PacMan_AteEnergizer();

        public void OnMoved(IMovable sender, MovedEventArgs args)
        {
            Task.Run(() => Moved?.Invoke(sender, args));
        }

        public void Act() => State.Act();
    }
}