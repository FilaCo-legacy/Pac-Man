namespace GameServer.GameObjects
{
    public abstract class GameObject : ICollidable
    {
        public int Row { get; set; }
        
        public int Column { get; set; }

        public abstract GameObjectCode Code { get; }

        public void Set(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public abstract void CollideWith(ICollidable other);
    }
}