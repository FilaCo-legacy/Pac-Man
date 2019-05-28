using System.Collections.Generic;
using System.Linq;
using GameServer.GameObjects;

namespace GameServer
{
    public class Bfs
    {
        private readonly SortedSet<MapPoint> _used;

        private readonly SortedDictionary<MapPoint, MapPoint> _parent;

        private readonly Queue<MapPoint> _queue;

        private MoveDirection _result;

        public Bfs()
        {
            _used = new SortedSet<MapPoint>();
            _parent = new SortedDictionary<MapPoint, MapPoint>();
            _queue = new Queue<MapPoint>();
        }

        private void Initialize()
        {
            _used.Clear();
            _parent.Clear();
            _queue.Clear();
        }

        private void DefineDirection(MapPoint startEntry, MapPoint endEntry)
        {
            var curPoint = endEntry;

            while (_parent[curPoint] != startEntry)
                curPoint = _parent[curPoint];

            _result = (MoveDirection)startEntry.GetNeighbours.ToList().FindIndex(neighbour => neighbour == curPoint);
        }

        private bool Step(MapPoint startPnt, MapPoint endPnt)
        {
            var curPoint = _queue.Dequeue();

            foreach (var neighbour in curPoint.GetNeighbours)
            {
                if (_used.Contains(neighbour))
                    continue;

                _used.Add(neighbour);
                _queue.Enqueue(neighbour);
                _parent[neighbour] = curPoint;

                if (neighbour != endPnt) 
                    continue;
                
                DefineDirection(startPnt, endPnt);
                
                return true;
            }

            return false;
        }
        
        public MoveDirection FindDirection(MapPoint startPnt, MapPoint endPnt)
        {
            Initialize();

            _used.Add(startPnt);
            _queue.Enqueue(startPnt);

            while (_queue.Count > 0 && !Step(startPnt, endPnt)){}

            return _result;
        }
        
        public int Distance(MapPoint startPnt, MapPoint endPnt)
        {
            Initialize();
            
            _used.Add(startPnt);
            _queue.Enqueue(startPnt);

            var len = 0;

            while (_queue.Count > 0 && !Step(startPnt, endPnt))
            {
                ++len;
            }

            return len;
        }
    }
}