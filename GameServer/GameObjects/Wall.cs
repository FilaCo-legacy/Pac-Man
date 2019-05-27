namespace GameServer.GameObjects
{
    public class Wall : GameObject
    {
        public override GameObjectCode Code => GameObjectCode.Wall;

        public override void CollideWith(ICollidable other) => other.CollideWith(this);
    }
}