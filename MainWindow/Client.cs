using GameServer;
using GameServer.GameMap;
using GameServer.GameObjects;
using Gdk;

namespace MainWindow
{
    public class Client
    {
        private readonly GameLoop _serverLoop;

        public IMapLoader MapLoader { get; set; }

        public event GameLoop.StepFinishedEventHandler StepFinished;

        public Client(IMapLoader mapLoader)
        {
            MapLoader = mapLoader;
            _serverLoop = new GameLoop(new Scene(), new Map(MapLoader));
            _serverLoop.StepFinished += OnStepFinished;
        }

        private void OnStepFinished(object sender, StepFinishedEventArgs args)
        {
            StepFinished?.Invoke(sender, args);
        }

        public void AddActor(IActor actor)
        {
            _serverLoop.Scene.Add(actor);
        }

        public void SetScene(Scene scene)
        {
            _serverLoop.Scene = scene;
        }

        public void SetMap(Map map)
        {
            _serverLoop.Map = map;
        }
        
        public void SetMap(IMapLoader mapLoader)
        {
            _serverLoop.Map = new Map(mapLoader);
        }
    }
}