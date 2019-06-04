using GameServer.GameObjects;

namespace GameServer.GameMap
{
    public interface IMapLoader
    {
        MapObjCode[,] Load();
    }
}