using System.Threading.Tasks;
using GameServer.GameMap;
using GameServer.GameObjects.Ghosts.GhostStates;

namespace GameServer.GameObjects.Ghosts
{
    public abstract class Ghost : IActor
    {
        public IGhostState State { private get; set; }
        
        public MapPoint Position { get; set; }

        protected Ghost()
        {
            
        }

        public void Act() => State.Act();
    }
}