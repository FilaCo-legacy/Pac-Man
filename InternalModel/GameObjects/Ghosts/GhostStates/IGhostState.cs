using GameServer.GameMap;

namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public interface IGhostState
    {
        MoveDirection ChooseDirection(MapPoint startPoint);
        
        int Ticks { get; }
        
        int AnimateStates { get; }
    }
}