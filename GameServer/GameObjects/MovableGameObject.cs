using System;

namespace GameServer.GameObjects
{

    public delegate void MovedEventHandler(MoveDirection direction);
    
    public abstract class MovableGameObject : GameObject
    {
        public virtual MoveDirection Direction { get; set; }

        public event MovedEventHandler Moved;

        public virtual void OnMoved()
        {
            Moved?.Invoke(Direction);
        }
    }
}