using GameServer.GameObjects;

namespace GameServer.GameMap
{
    public interface IMap
    {
        MapObjCode this [int row, int column] { get; set; }
    }
}