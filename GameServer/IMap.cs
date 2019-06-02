using GameServer.GameObjects;

namespace GameServer
{
    public interface IMap
    {
        int Width { get; }
        
        int Height { get; }
        
        MapObjCode this[int row, int col] { get; }
    }
}