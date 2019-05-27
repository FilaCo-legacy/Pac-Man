namespace GameServer.GameObjects
{
    public class Void : GameObject
    {
        public override GameObjectCode Code => GameObjectCode.Void;

        public override void CollideWith(ICollidable other) => other.CollideWith(this);
    }
}