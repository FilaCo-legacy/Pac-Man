using System;

namespace GameServer
{
    public class Map
    {
        private static readonly Map _instance = new Map();

        public static Map GetInstance => _instance;

        public const int Width = 28;

        public const int Height = 31;

        private object _lock;
        
        private readonly IMapEntry[,] _matrixMap;

        public IMapEntry this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= Height || column < 0 || column >= Width)
                    throw new Exception("Incorrect indexes");

                return _matrixMap[row, column];
            }
            set
            {
                if (row < 0 || row >= Height || column < 0 || column >= Width)
                    throw new Exception("Incorrect indexes");

                lock (_lock)
                {
                    _matrixMap[row, column] = value;
                }
            }
        }
        
        public Map()
        {
            _matrixMap = new IMapEntry[Height, Width];
        }
    }
}