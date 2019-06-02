using GameServer;
using GameServer.GameMap;
using GameServer.GameObjects;
using Gdk;

namespace MainWindow
{
    public class Client
    {
        private readonly GameModel _serverModel;

        public IMapLoader MapLoader { get; set; }
        

        public Client(IMapLoader mapLoader)
        {
            MapLoader = mapLoader;
            _serverModel = new GameModel(new Scene(), MapLoader.Load());
            _serverModel.StepFinished += OnStepFinished;
        }

        private void OnStepFinished(object sender, StepFinishedEventArgs args)
        {
            
        }

        public void AddActor(IActor actor)
        {
            _serverModel.Scene.Add(actor);
        }
        
        public void SetMap()
        {
            _serverModel.Map = MapLoader.Load();
        }
    }
}