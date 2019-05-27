namespace GameServer.GameObjects
{
    public class Energizer : GameObject
    {
        public override GameObjectCode Code => GameObjectCode.Energizer;
        public override void CollideWith(ICollidable other) => other.CollideWith(this);
    }
}