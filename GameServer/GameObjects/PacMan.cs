using System.Threading.Tasks;
using GameServer.GameObjects.Ghosts;

namespace GameServer.GameObjects
{
    public class PacMan : MovableGameObject
    {
        public delegate void FoodEatenEventHandler(object sender, FoodEatenEventArgs args);

        public delegate void FruitEatenEventHandler(object sender, FruitEatenEventArgs args);

        public delegate void EnergizerEatenEventHandler(object sender, EnergizerEatenEventArgs args);

        public delegate void DiedEventHandler(object sender, DiedEventArgs args);

        public event FoodEatenEventHandler FoodEaten;

        public event FruitEatenEventHandler FruitEaten;

        public event EnergizerEatenEventHandler EnergizerEaten;

        public event DiedEventHandler Died;
        
        public IMoveStrategy MoveStrategy { get; set; }
        
        public MoveDirection Direction { get; set; }

        public override GameObjectCode Code => GameObjectCode.Pac_Man;

        public override void CollideWith(ICollidable other) => other.CollideWith(this);

        public void OnFoodEaten(object sender, FoodEatenEventArgs args)
        {
            FoodEaten?.Invoke(sender, args);
        }

        public void OnFruitEaten(object sender, FruitEatenEventArgs args)
        {
            FruitEaten?.Invoke(sender, args);
        }
        
        public void OnEnergizerEaten(object sender, EnergizerEatenEventArgs args)
        {
            EnergizerEaten?.Invoke(sender, args);
        }
        
        public void OnDied(object sender, DiedEventArgs args)
        {
            Died?.Invoke(sender, args);
        }
        
        public void Move() => MoveStrategy.Move();

        public void CollideWith(Food foodObj)
        {
            ChangeLocation();
            CollideWithPurge();
            OnFoodEaten(this, new FoodEatenEventArgs());
        }
        
        public void CollideWith(Fruit fruitObj)
        {
            ChangeLocation();
            CollideWithPurge();
            OnFruitEaten(this, new FruitEatenEventArgs());
        }
        
        public void CollideWith(Energizer energizerObj)
        {
            ChangeLocation();
            CollideWithPurge();
            OnEnergizerEaten(this, new EnergizerEatenEventArgs());
        }

        public void CollideWith(Ghost ghostObj)
        {
            
        }
    }
}