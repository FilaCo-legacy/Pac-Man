using System.Collections.Generic;

namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public class Bfs
    {
        private readonly bool [,] _used;

        private static readonly int[] MoveX = {1, 0, -1, 0};

        private static readonly int[] MoveY = {0, 1, 0, -1};

        private readonly MapPoint[,] _parent;

        private readonly Queue<MapPoint> _queue;

        private MoveDirection _result;

        public Bfs()
        {
            _used = new bool[Map.GetInstance.Height,Map.GetInstance.Width];
            _parent = new MapPoint[Map.GetInstance.Height, Map.GetInstance.Width];
            _queue = new Queue<MapPoint>();
        }

        private void Initialize()
        {
            for (var i = 0; i < _used.GetLength(0); ++i)
            {
                for (var j = 0; j < _used.GetLength(1); ++j)
                {
                    _used[i, j] = false;
                    _parent[i, j] = new MapPoint {Row = i, Column = j};
                }
            }
            
            _queue.Clear();
        }

        private void FindDirection(MapPoint startPoint, MapPoint endPoint)
        {
            var curPoint = endPoint;

            while (_parent[curPoint.Row, curPoint.Column] != startPoint)
                curPoint = _parent[curPoint.Row, curPoint.Column];

            var tmpPoint = new MapPoint();

            for (var dir = 0; dir < MapPoint.CountNeighbours; ++dir)
            {
                tmpPoint.Set(curPoint.Row + MoveY[dir], curPoint.Column + MoveX[dir]);
                if (tmpPoint != curPoint)
                    continue;
                _result = (MoveDirection) dir;
                break;
            }
        }

        private bool Step(MapPoint startPoint, MapPoint endPoint)
        {
            var curPoint = _queue.Dequeue();

            for (var dir = 0; dir < MapPoint.CountNeighbours; ++dir)
            {
                var targetPoint = new MapPoint
                {
                    Column = curPoint.Column + MoveX[dir],
                    Row = curPoint.Row + MoveY[dir]
                };

                if (targetPoint.IsValid)
                {
                    _used[targetPoint.Row, targetPoint.Column] = true;
                    _parent[targetPoint.Row, targetPoint.Column] = curPoint;
                    _queue.Enqueue(targetPoint);
                }

                if (targetPoint != endPoint) 
                    continue;
                
                FindDirection(startPoint, endPoint);
                return true;
            }

            return false;
        }
        
        public MoveDirection Execute(MapPoint startPoint, MapPoint endPoint)
        {
            Initialize();
            
            _used[startPoint.Row, startPoint.Column] = true;
            _queue.Enqueue(startPoint);

            while (_queue.Count > 0 && !Step(startPoint, endPoint)){}

            return _result;
        }
    }
}