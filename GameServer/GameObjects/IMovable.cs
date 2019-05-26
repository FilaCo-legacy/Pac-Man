namespace GameServer.GameObjects
{
    public enum MoveDirection
    {
        Right,
        Down,
        Left,
        Up
    }
    
    public interface IMovable
    {
        void Move();
    }
}