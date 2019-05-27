using System.Collections.Generic;
using System.Linq;
using GameServer.GameObjects;

namespace GameServer
{
    public class Bfs
    {
        private readonly bool [,] _used;

        private readonly MapPoint[,] _parent;

        private readonly Queue<MapPoint> _queue;

        private MoveDirection _result;

        public Bfs()
        {
            _used = new bool[Map.Height, Map.Width];
            _parent = new MapPoint[Map.Height, Map.Width];
            _queue = new Queue<MapPoint>();
        }

        private void Initialize()
        {
            for (var row = 0; row < _used.GetLength(0); ++row)
            {
                for (var column = 0; column < _used.GetLength(1); ++column)
                {
                    _used[row, column] = false;
                    _parent[row, column].Set(row, column);
                }
            }
            
            _queue.Clear();
        }

        private void FindDirection(MapPoint startEntry, MapPoint endEntry)
        {
            var curPoint = endEntry;

            while (_parent[curPoint.Row, curPoint.Column] != startEntry)
                curPoint = _parent[curPoint.Row, curPoint.Column];

            _result = (MoveDirection)startEntry.GetNeighbours.ToList().FindIndex(neighbour => neighbour == curPoint);
        }

        private bool Step(MapPoint startPnt, MapPoint endPnt)
        {
            var curPoint = _queue.Dequeue();

            foreach (var neighbour in curPoint.GetNeighbours)
            {
                if (!neighbour.IsValid || _used[neighbour.Row, neighbour.Column] ||
                    Map.GetInstance[neighbour].Peek() == GameObjectCode.Wall) 
                    continue;
                
                _used[neighbour.Row, neighbour.Column] = true;
                _queue.Enqueue(neighbour);
                _parent[neighbour.Row, neighbour.Column] = curPoint;

                if (neighbour != endPnt) 
                    continue;
                
                FindDirection(startPnt, endPnt);
                
                return true;
            }

            return false;
        }
        
        public MoveDirection Execute(MapPoint startPnt, MapPoint endPnt)
        {
            Initialize();
            
            _used[startPnt.Row, startPnt.Column] = true;
            _queue.Enqueue(startPnt);

            while (_queue.Count > 0 && !Step(startPnt, endPnt)){}

            return _result;
        }
    }
}