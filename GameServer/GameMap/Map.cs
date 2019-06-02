using System;
using GameServer.GameObjects;

namespace GameServer.GameMap
{
    public class Map
    {
        private readonly object _lock;
        
        private readonly MapObjCode[,] _map;

        private readonly IMapLoader _mapLoader;
        
        public int Width { get; }

        public int Height { get; }

        public MapObjCode this[int row, int column]
        {
            get
            {
                lock (_lock)
                {
                    if (row < 0 || row >= Height || column < 0 || column >= Width)
                        throw new Exception("Incorrect indexes");

                
                    return _map[row, column];
                }
            }
            set
            {
                lock (_lock)
                {
                    if (row < 0 || row >= Height || column < 0 || column >= Width)
                        throw new Exception("Incorrect indexes");


                    _map[row, column] = value;
                }
            }
        }

        public MapObjCode this[MapPoint point]
        {
            get => this[point.Row, point.Column];
            set => this[point.Row, point.Column] = value;
        }

        public Map(IMapLoader mapLoader)
        {
            _mapLoader = mapLoader;
            _mapLoader.Load(out _map);
            _lock = new object();
        }
    }
}