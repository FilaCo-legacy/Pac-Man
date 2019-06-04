using System;
using GameServer.GameObjects;

namespace GameServer.GameMap
{
    public class Map
    {
        private  static readonly Map Instance = new Map();

        public static Map GetInstance => Instance;
        
        private MapObjCode[,] _map;

        public int Width => _map.GetLength(1);

        public int Height => _map.GetLength(0);

        public int FoodCount => 240;

        public int EnergizerCount => 4;

        public MapObjCode this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= Height || column < 0 || column >= Width)
                    throw new Exception("Incorrect indexes");
                
                return _map[row, column];
            }
            set
            {
                if (row < 0 || row >= Height || column < 0 || column >= Width)
                    throw new Exception("Incorrect indexes");

                _map[row, column] = value;
            }
        }

        public MapPoint StartPacManLocation => new MapPoint(20, 13);

        public MapObjCode this[MapPoint point]
        {
            get => this[point.Row, point.Column];
            set => this[point.Row, point.Column] = value;
        }
        
        private Map()
        {
            _map = new MapFromFileLoader().Load();
        }

        public void Refresh()
        {
            _map = new MapFromFileLoader().Load();
        }
    }
}