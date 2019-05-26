namespace GameServer.GameObjects.Ghosts
{
    public abstract class Ghost : GameObject, IMovable
    {
        public IGhostState State { get; set; }
        
        public MoveDirection Direction { get; set; }

        protected Ghost()
        {
            
        }
        
        public void Move() => State.Move();
    }
}