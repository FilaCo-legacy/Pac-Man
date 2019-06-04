using GameServer.GameObjects;

namespace GameServer
{
    public interface IScene
    {
        void Update();

        void Add(IActor actor);
    }
}