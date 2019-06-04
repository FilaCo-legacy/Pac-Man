using System.Threading.Tasks;
using GameServer.GameMap;
using GameServer.GameObjects.Ghosts.GhostStates;

namespace GameServer.GameObjects.Ghosts
{
    public abstract class Ghost : GameActor
    {
        public const int MaxTimesScatter = 4;
        
        public IGhostState State { get; set; }

        public override int Ticks => State.Ticks;

        public override int AnimateStates => State.AnimateStates;
        public int TimesScatter { get; set; }

        public abstract MapPoint TargetPointScatter { get; }
        
        public abstract MapPoint TargetPointChase { get; }
        
        public static MapPoint TargetBeginPoint => new MapPoint(14, 13);

        protected Ghost()
        {
            State = new BeginState(this);
        }

        public override void Act()
        {
            var nextDir = Direction;
            
            if (_elapsedTicks == Ticks)
                 nextDir = State.ChooseDirection(Position[Direction]);
            
            base.Act();

            Direction = nextDir;
        }
    }
}