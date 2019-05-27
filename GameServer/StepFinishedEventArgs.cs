using GameServer.GameObjects;

namespace GameServer
{
    public class StepFinishedEventArgs
    {
        public float Alpha { get; }
        
        public GameObjectCode [,] MapCodes { get; }

        public StepFinishedEventArgs(float alpha, GameObjectCode [,] mapCodes)
        {
            Alpha = alpha;
            MapCodes = mapCodes;
        }
    }
}