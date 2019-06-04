using System.Threading.Tasks;
using GameServer.GameMap;
using GameServer.GameObjects.Ghosts.GhostStates;

namespace GameServer.GameObjects.Ghosts
{
    public abstract class Ghost : GameActor
    {
        public const int MaxTimesScatter = 4;
        
        public IGhostState State { get; set; }

        protected override int MillisecondsSkip => State.Ticks;
        
        public int TimesScatter { get; set; }

        public abstract MapPoint TargetPointScatter { get; }
        
        public abstract MapPoint TargetPointChase { get; }

        protected Ghost()
        {
            
        }

        public override void Act()
        {
            var nextDir = State.ChooseDirection(Position[Direction]);
            
            base.Act();

            Direction = nextDir;
        }
    }
}