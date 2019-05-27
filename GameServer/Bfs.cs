using System.Collections.Generic;
using System.Linq;
using GameServer.GameObjects;

namespace GameServer
{
    public class Bfs
    {
        private readonly bool [,] _used;

        private readonly MapEntry[,] _parent;

        private readonly Queue<MapEntry> _queue;

        private MoveDirection _result;

        public Bfs()
        {
            _used = new bool[Map.GetInstance.Height,Map.GetInstance.Width];
            _parent = new MapEntry[Map.GetInstance.Height, Map.GetInstance.Width];
            _queue = new Queue<MapEntry>();
        }

        private void Initialize()
        {
            for (var i = 0; i < _used.GetLength(0); ++i)
            {
                for (var j = 0; j < _used.GetLength(1); ++j)
                {
                    _used[i, j] = false;
                    _parent[i, j] = new MapEntry(i, j);
                }
            }
            
            _queue.Clear();
        }

        private void FindDirection(MapEntry startEntry, MapEntry endEntry)
        {
            var curPoint = endEntry;

            while (_parent[curPoint.Row, curPoint.Column] != startEntry)
                curPoint = _parent[curPoint.Row, curPoint.Column];

            _result = (MoveDirection)startEntry.GetNeighbours.ToList().FindIndex(neighbour => neighbour == curPoint);
        }

        private bool Step(MapEntry startEntry, MapEntry endEntry)
        {
            var curPoint = _queue.Dequeue();

            foreach (var neighbour in curPoint.GetNeighbours)
            {
                if (!neighbour.IsValid || _used[neighbour.Row, neighbour.Column] || neighbour.Content is Wall) 
                    continue;
                
                _used[neighbour.Row, neighbour.Column] = true;
                _queue.Enqueue(neighbour);
                _parent[neighbour.Row, neighbour.Column] = curPoint;

                if (neighbour != endEntry) 
                    continue;
                
                FindDirection(startEntry, endEntry);
                
                return true;
            }

            return false;
        }
        
        public MoveDirection Execute(MapEntry startEntry, MapEntry endEntry)
        {
            Initialize();
            
            _used[startEntry.Row, startEntry.Column] = true;
            _queue.Enqueue(startEntry);

            while (_queue.Count > 0 && !Step(startEntry, endEntry)){}

            return _result;
        }
    }
}