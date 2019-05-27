namespace GameServer.GameObjects.Ghosts.GhostStates
{
    public struct MapPoint
    {
        public const int CountNeighbours = 4;
        
        public int Row { get; set; }
        
        public int Column { get; set; }

        public bool IsValid => Row > 0 && Column > 0 && Row < Map.GetInstance.Height && Column < Map.GetInstance.Width;

        public void Set(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public static bool operator ==(MapPoint lhs, MapPoint rhs)
        {
            return lhs.Row == rhs.Row && lhs.Column == rhs.Column;
        }

        public static bool operator !=(MapPoint lhs, MapPoint rhs)
        {
            return !(lhs == rhs);
        }
        
        public bool Equals(MapPoint other)
        {
            return Row == other.Row && Column == other.Column;
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