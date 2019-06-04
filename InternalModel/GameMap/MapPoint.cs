using System.Collections.Generic;
using GameServer.GameObjects;

namespace GameServer.GameMap
{
    public struct MapPoint
    {
        public const int CountNeighbour = 4;
        
        private static readonly int[] ShiftX = {1, 0, -1, 0};

        private static readonly int[] ShiftY = {0, 1, 0, -1};

        public MapPoint(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; set; }
        
        public int Column { get; set; }

        public MapPoint this[MoveDirection direction]
        {
            get
            {
                var ind = (int) direction;
                
                return new MapPoint(Row + ShiftY[ind], Column + ShiftX[ind]);
            }
        }
        
        public IEnumerable<MapPoint> GetNeighbours
        {
            get
            {
                var neighbours = new List<MapPoint>();

                for (var direction = 0; direction < CountNeighbour; ++direction)
                {
                    neighbours.Add(new MapPoint(Row + ShiftY[direction], Column + ShiftX[direction]));
                }

                return neighbours;
            }
        }
        
        public bool IsValid(Map map)  => Row > 0 && Column > 0 && Row < map.Height && Column < map.Width;

        public static bool operator ==(MapPoint lhs, MapPoint rhs) => lhs.Row == rhs.Row && lhs.Column == rhs.Column;

        public static bool operator !=(MapPoint lhs, MapPoint rhs) => !(lhs == rhs);
        
        public static MapPoint operator - (MapPoint lhs, MapPoint rhs) => 
            new MapPoint(lhs.Row - rhs.Row, lhs.Column - rhs.Column);
        
        public static MapPoint operator + (MapPoint lhs, MapPoint rhs) => 
            new MapPoint(lhs.Row + rhs.Row, lhs.Column + rhs.Column);
        
        private bool Equals(MapPoint other)
        {
            return Row == other.Row && Column == other.Column;
        }

        public void Set(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object obj)
        {
            return obj is MapPoint other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Column;
            }
        }
    }
}