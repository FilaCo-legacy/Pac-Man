using GameServer.GameObjects;
using GameServer.GameObjects.Ghosts;

namespace GameServer
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
            var targetPnt = sender.Position[sender.Direction];

            if (!targetPnt.IsValid) return;
            
            Map.GetInstance[sender.Position].Pop();

            sender.Position = targetPnt;
                
            Map.GetInstance[sender.Position].Push(args.Code);
        }
    }
}