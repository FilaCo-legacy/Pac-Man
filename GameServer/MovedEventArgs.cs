using GameServer.GameObjects;

namespace GameServer
{
    public class MovedEventArgs
    {
        public GameObjectCode Code { get; }

        public MovedEventArgs(GameObjectCode code) => Code = code;
    }
}