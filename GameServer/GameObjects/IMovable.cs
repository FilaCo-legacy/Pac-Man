using GameServer.GameMap;

namespace GameServer.GameObjects
{
    public delegate void MovedEventHandler(IMovable sender, MovedEventArgs args);
    
    public interface IMovable
    {
        MoveDirection Direction { get; }
        
        MapPoint Position { get; set; }
        
        event MovedEventHandler Moved;
    }
}