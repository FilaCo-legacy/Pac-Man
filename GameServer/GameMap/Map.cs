using System;
using GameServer.GameObjects;

namespace GameServer.GameMap
{
    public class Map : IMap
    {
        private readonly object _lock;

        private readonly MapObjCode[,] _storedMap;
        
        private readonly MapObjCode[,] _map;

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

        public MapObjCode this[MapPoint point]
        {
            get => this[point.Row, point.Column];
            set => this[point.Row, point.Column] = value;
        }

        public void Refresh()
        {
            for (var row = 0; row < Height; ++row)
            {
                for (var column = 0; column < Width; ++column)
                    _map[row, column] = _storedMap[row, column];
            }
        }

        public Map(MapObjCode[,] matrixObjCodes, int foodCount, int energizerCount)
        {
            _lock = new object();
            _storedMap = (MapObjCode[,])matrixObjCodes.Clone();
            _map = (MapObjCode[,])matrixObjCodes.Clone();
            FoodCount = foodCount;
            EnergizerCount = energizerCount;

            
        }
    }
}