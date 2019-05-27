using System.Threading.Tasks;

namespace GameServer.GameObjects
{
    public class PacMan : GameObject, IMovable
    {
        public IMoveStrategy MoveStrategy { get; set; }
        
        public MoveDirection Direction { get; set; }

        public override GameObjectCode Code => GameObjectCode.Pac_Man;
        
        public void Move() => MoveStrategy.Move();
        
        
    }
}