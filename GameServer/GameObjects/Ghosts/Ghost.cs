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

        protected Ghost()
        {
            PacMan.GetInstance.AteSmth += OnPacManAteSmth; 
        }

        private void OnPacManAteSmth(PacMan_EatEventArgs args) => State.OnPacManAteSmth(args);

        public OnPacManReaction ReactOnPacMan => State.ReactOnPacMan;

        public void OnMoved(IMovable sender, MovedEventArgs args)
        {
            Moved?.Invoke(sender, args);
        }

        public void Act() => State.Act();
    }
}