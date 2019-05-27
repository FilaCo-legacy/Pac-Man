using GameServer.GameObjects.Ghosts.GhostStates;

namespace GameServer.GameObjects.Ghosts
{
    public abstract class Ghost : MovableGameObject
    {
        public IGhostState State { get; set; }

        protected Ghost()
        {
            
        }

        public void Move()
        {
            
        }
        
        public abstract GameObjectCode DefaultCode { get; }

        public override GameObjectCode Code => State.Code;
    }
}