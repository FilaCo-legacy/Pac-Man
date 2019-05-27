using System;

namespace GameServer.GameObjects
{
    public abstract class MovableGameObject : GameObject
    {
        protected static readonly int[] MoveX = new[] {1, 0, -1, 0};

        protected static readonly int[] MoveY = new[] {0, 1, 0, -1};
        
        protected GameObject _coveredGameObject;
        
        public MoveDirection Direction { get; set; }
        
        public GameObject[] Neighbours
        {
            get
            {
                var neighbours = new GameObject[4];

                for (var i = 0; i < neighbours.Length; ++i)
                {
                    neighbours[i] = Map.GetInstance[Row + MoveY[i], Column + MoveX[i]];
                }

                return neighbours;
            }
        }

        protected void ChangeLocation()
        {
            Map.GetInstance[Row, Column] = _coveredGameObject;
            
            Row += MoveY[(int) Direction];
            Column += MoveX[(int) Direction];
        }
        
        protected void CollideWithPurge()
        {
            _coveredGameObject = new Void{Column = Column, Row = Row};
            Map.GetInstance[Row ,Column] = this;
        }

        protected void CollideWithStore()
        {
            _coveredGameObject = Map.GetInstance[Row, Column];
            Map.GetInstance[Row ,Column] = this;
        }
        
        public void Move()
        {
            if (Neighbours[(int) Direction] != null)
            {
                CollideWith(Neighbours[(int) Direction]);
            }
        }

        public virtual void CollideWith(Void voidObj)
        {
            ChangeLocation();
            CollideWithStore();
        }

        public void CollideWith(Wall wallObj)
        {
            
        }
    }
}