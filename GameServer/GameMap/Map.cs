using System;

namespace GameServer.GameMap
{
    public class Map
    {
        public static readonly MapPoint LeftUpperGhostRoom = new MapPoint(13, 11);

        public const int GhostRoomWidth = 5;

        public const int GhostRoomHeight = 3;
        
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
        }

        public MapEntry this[MapPoint point] => this[point.Row, point.Column];

        private Map()
        {
            _matrixMap = new MapEntry[Height,Width];
            _lock = new object();
        }
    }
}