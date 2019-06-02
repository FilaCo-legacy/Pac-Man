using GameServer.GameObjects;

namespace GameServer.GameMap
{
    public interface IMapLoader
    {
        void Load(out MapObjCode [,] map);
    }
}