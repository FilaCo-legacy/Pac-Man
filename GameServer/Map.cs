using System;
using GameServer.GameObjects;

namespace GameServer
{
    public class Map
    {
        private static readonly Map Instance = new Map();

        public static Map GetInstance => Instance;
        
        public int Width { get; set; }

        public int Height { get; set; }

        private readonly object _lock;
        
        private readonly GameObject[,] _matrixMap;

        public GameObject this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= Height || column < 0 || column >= Width)
                    return null;

                lock (_lock)
                {
                    return _matrixMap[row, column];
                }
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
            _lock = new object();
        }

        public GameObjectCode[,] GetMapInfo()
        {
            var transMatrix = new GameObjectCode[Height, Width];

            for (var i = 0; i < Height; ++i)
            {
                for (var j = 0; j < Width; ++j)
                {
                    transMatrix[i, j] = this[i, j].Code;
                }
            }

            return transMatrix;
        }
    }
}