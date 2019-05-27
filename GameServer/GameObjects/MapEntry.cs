using System.Collections.Generic;

namespace GameServer.GameObjects
{
    public struct MapEntry
    {
        private static readonly int[] ShiftX = {1, 0, -1, 0};

        private static readonly int[] ShiftY = {0, 1, 0, -1};
        
        public const int CountNeighbours = 4;

        private GameObject _content;
        public GameObject Content
        {
            get => _content;
            set
            {
                if (_content is MovableGameObject)
                    ((MovableGameObject) _content).Moved -= 
            }
        }
        
        public int Row { get; }
        
        public int Column { get; }
        
        public IEnumerable<MapEntry> GetNeighbours
        {
            get
            {
                var listNeighbours = new List<MapEntry>();

                for (var dir = 0; dir < CountNeighbours; ++dir)
                    listNeighbours.Add(new MapEntry(Row + ShiftX[dir], Column + ShiftY[dir]));

                return listNeighbours;
            }
        }

        public bool IsValid => Row > 0 && Column > 0 && Row < Map.GetInstance.Height && Column < Map.GetInstance.Width;

        public MapEntry(int row, int column, GameObject content = null)
        {
            Row = row;
            Column = column;
            _content = content;
        }

        public static bool operator ==(MapEntry lhs, MapEntry rhs)
        {
            return lhs.Row == rhs.Row && lhs.Column == rhs.Column;
        }

        public static bool operator !=(MapEntry lhs, MapEntry rhs)
        {
            return !(lhs == rhs);
        }

        private bool Equals(MapEntry other)
        {
            return Row == other.Row && Column == other.Column;
        }

        public override bool Equals(object obj)
        {
            return obj is MapEntry other && Equals(other);
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