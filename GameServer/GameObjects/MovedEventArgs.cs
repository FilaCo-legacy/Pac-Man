using GameServer.GameMap;

namespace GameServer.GameObjects
{
    public class MovedEventArgs
    {
        public MapPoint DesiredPosition { get; }

        public MovedEventArgs(MapPoint desiredPosition) => DesiredPosition = desiredPosition;
    }
}