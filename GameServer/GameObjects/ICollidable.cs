namespace GameServer
{
    public interface ICollidable
    {
        void CollideWith(ICollidable other);
    }
}