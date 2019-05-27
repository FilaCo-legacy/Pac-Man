using GameServer.GameObjects.Ghosts.GhostStates;

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
        
        public abstract GameObjectCode DefaultCode { get; }

        public override GameObjectCode Code => State.Code;
    }
}