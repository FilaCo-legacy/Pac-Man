using System;
using GameServer.GameObjects;

namespace GameServer.GameMap
{
    public class Map
    {
        public static readonly MapPoint LeftUpperGhostRoom = new MapPoint(13, 11);

        public const int GhostRoomWidth = 5;

        public const int GhostRoomHeight = 3;
        
        private static readonly Map Instance = new Map();

        public static Map GetInstance => Instance;

        private int _foodCount;

        private int _energizerCount;

        private readonly object _lock;
        
        private readonly GameObjectCode[,] _matrixMap;

        public const int Width = 28;

        public const int Height = 31;
        
        public MapChecker Checker { get; }

        public GameObjectCode this[int row, int column]
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

        public GameObjectCode this[MapPoint point]
        {
            get => this[point.Row, point.Column];
            set => this[point.Row, point.Column] = value;
        }

        public bool IsVictory => _energizerCount == 0 && _foodCount == 0;

        private Map()
        {
            PacMan.GetInstance.AteSmth += OnPacManAteSmth;
            
            Checker = new MapChecker();
            _matrixMap = new GameObjectCode[Height,Width];
            _lock = new object();
            _energizerCount = 4;
            _foodCount = 240;
        }

        private void OnPacManAteSmth(PacMan_EatEventArgs args)
        {
            this[PacMan.GetInstance.Position] = GameObjectCode.Void;

            if (args.EatenObject == GameObjectCode.Energizer)
                _energizerCount--;
            else if (args.EatenObject == GameObjectCode.Food)
                _foodCount--;
        }
    }
}