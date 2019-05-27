namespace GameServer.GameObjects
{
    public delegate void MovedEventHandler(IMovable sender, MovedEventArgs args);
    
    public interface IMovable
    {
        MoveDirection Direction { get; }
        
        int Row { get; set; }
        
        int Column { get; set; }
        
        event MovedEventHandler Moved;
    }
}