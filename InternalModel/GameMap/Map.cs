using System;
using GameServer.GameObjects;

namespace GameServer.GameMap
{
    public class Map : IMap
    {
        private MapObjCode[,] _map;

        public int Width => _map.GetLength(1);

        public int Height => _map.GetLength(0);
        
        public int FoodCount { get; }
        
        public int EnergizerCount { get; }

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

        public MapPoint StartPacManLocation { get; }

        public MapObjCode this[MapPoint point]
        {
            get => this[point.Row, point.Column];
            set => this[point.Row, point.Column] = value;
        }
        
        public Map()
        {
        }

        public void Refresh()
        {
            _map = new MapFromFileLoader().Load();
        }
    }
}