using GameServer.GameObjects;

namespace GameServer
{
    public interface IMapEntry
    {
        GameObject Contains { get; set; }
    }
}