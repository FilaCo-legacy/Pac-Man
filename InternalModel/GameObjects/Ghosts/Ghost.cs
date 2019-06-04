using System.Threading.Tasks;
using GameServer.GameMap;
using GameServer.GameObjects.Ghosts.GhostStates;

namespace GameServer.GameObjects.Ghosts
{
    public abstract class Ghost : GameActor
    {
        public IGhostState State { private get; set; }

        protected Ghost()
        {
            
        }
    }
}