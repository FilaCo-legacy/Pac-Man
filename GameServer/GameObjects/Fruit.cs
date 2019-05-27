namespace GameServer.GameObjects
{
    public class Fruit : GameObject
    {
        public override GameObjectCode Code => GameObjectCode.Fruit;

        public override void CollideWith(ICollidable other) => other.CollideWith(this);
    }
}