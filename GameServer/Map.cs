using System;
using GameServer.GameObjects;

namespace GameServer
{
    public class Map
    {
        private static readonly Map Instance = new Map();

        public static Map GetInstance => Instance;

        private readonly object _lock;
        
        private readonly MapEntry[,] _matrixMap;

        public const int Width = 28;

        public const int Height = 31;

        public MapEntry this[int row, int column]
        {
            get
            {
                lock (_lock)
                {
                    if (row < 0 || row >= Height || column < 0 || column >= Width)
                        throw new Exception("Incorrect indexes");

                
                    return _matrixMap[row, column];
                }
            }
            set
            {
                lock (_lock)
                {
                    if (row < 0 || row >= Height || column < 0 || column >= Width)
                        throw new Exception("Incorrect indexes");

                
                    _matrixMap[row, column] = value;
                }
            }
        }

        private Map()
        {
            _matrixMap = new MapEntry[Height,Width];
            _lock = new object();
        }
    }
}