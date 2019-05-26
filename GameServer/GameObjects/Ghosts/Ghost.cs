namespace GameServer.GameObjects.Ghosts
{
    public abstract class Ghost : GameObject, IMovable
    {
        public IGhostState State { get; set; }

        public void Move() => State.Move();
    }
}