using GameServer.GameObjects;
using GameServer.GameObjects.Ghosts;

namespace GameServer
{
    public class MapDispatcher
    {
        private static readonly MapDispatcher Instance = new MapDispatcher();

        public static MapDispatcher GetInstance => Instance;
        
        private static readonly int[] ShiftX = {1, 0, -1, 0};

        private static readonly int[] ShiftY = {0, 1, 0, -1};

        private static bool IsValid(int row, int column) =>
            row > 0 && column > 0 && row < Map.Height && column < Map.Width;

        private MapDispatcher()
        {
            PacMan.GetInstance.Moved += Actor_Moved;
            Blinky.GetInstance.Moved += Actor_Moved;
            Inky.GetInstance.Moved += Actor_Moved;
            Pinky.GetInstance.Moved += Actor_Moved;
            Clyde.GetInstance.Moved += Actor_Moved;
        }

        private void Actor_Moved(IMovable sender, MovedEventArgs args)
        {
            var indDir = (int) sender.Direction;
            
            var nRow = sender.Row + ShiftY[indDir];
            var nCol = sender.Column + ShiftX[indDir];

            if (!IsValid(nRow, nCol)) return;
            
            Map.GetInstance[sender.Row, sender.Column].Pop();
                
            sender.Row = nRow;
            sender.Column = nCol;
                
            Map.GetInstance[sender.Row, sender.Column].Push(args.Code);
        }
    }
}