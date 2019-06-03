using System;
using GameServer.GameObjects;

namespace GameServer.GameMap
{
    public class Map 
    {
        private static readonly  Map _instance = new Map();

        public static Map GetInstance => _instance;

        private readonly object _lock;

        private MapObjCode[,] _map;

        public int Width => _map.GetLength(1);

        public int Height => _map.GetLength(0);
        
        public int FoodCount { get; }
        
        public int EnergizerCount { get; }

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

        public MapPoint StartPacManLocation { get; }

        public MapObjCode this[MapPoint point]
        {
            get => this[point.Row, point.Column];
            set => this[point.Row, point.Column] = value;
        }
        
        private Map()
        {
            _lock = new object();
            _map = new MapFromFileLoader().Load();
            FoodCount = 240;
            EnergizerCount = 4;
            StartPacManLocation = new MapPoint(17, 13);
        }

        public void Refresh()
        {
            _map = new MapFromFileLoader().Load();
        }
    }
}