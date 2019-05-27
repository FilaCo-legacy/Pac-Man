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
        
        private static readonly PacMan Instance = new PacMan();

        public static PacMan GetInstance => Instance;
        
        public IMoveStrategy MoveStrategy { get; set; }
        
        public MoveDirection Direction { get; set; }

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
    }
}