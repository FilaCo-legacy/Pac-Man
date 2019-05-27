using GameServer.GameObjects.Ghosts.GhostStates;

namespace GameServer.GameObjects.Ghosts
{
    public abstract class Ghost : IActor, IMovable
    {
        public IGhostState State { get; set; }
        
        public MoveDirection Direction => State.Direction;
        
        public MapPoint Position { get; set; }

        public event MovedEventHandler Moved;

        private void PacMan_AteEnergizer() => State.PacMan_AteEnergizer();

        public void OnMoved(IMovable sender, MovedEventArgs args)
        {
            Moved?.BeginInvoke(sender, args,null, null);
        }

        public void Act() => State.Act();
    }
}