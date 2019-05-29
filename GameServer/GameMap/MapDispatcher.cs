using GameServer.GameObjects;
using GameServer.GameObjects.Ghosts;

namespace GameServer.GameMap
{
    public class MapDispatcher
    {
        private MapDispatcher()
        {
            PacMan.GetInstance.Moved += Actor_Moved;
            Blinky.GetInstance.Moved += Actor_Moved;
            Inky.GetInstance.Moved += Actor_Moved;
            Pinky.GetInstance.Moved += Actor_Moved;
            Clyde.GetInstance.Moved += Actor_Moved;
        }

        private static void Actor_Moved(IMovable sender, MovedEventArgs args)
        {
            if (!args.DesiredPosition.IsValid || Map.GetInstance[args.DesiredPosition] == GameObjectCode.Wall) 
                return;

            sender.Position = args.DesiredPosition;
        }
    }
}