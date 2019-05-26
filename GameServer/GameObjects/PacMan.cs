namespace GameServer.GameObjects
{
    public class PacMan : GameObject, IMovable
    {
        private static readonly PacMan _instance = new PacMan();

        public static PacMan GetInstance => _instance;

        public IStrategy MoveStrategy { get; set; }
        
        public void Move() => MoveStrategy.Execute();
    }
}