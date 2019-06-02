using GameServer;
using GameServer.GameMap;
using GameServer.GameObjects;
using Gdk;

namespace MainWindow
{
    public class Client
    {
        public GameModel ServerModel { get; set; }

        public IMapLoader MapLoader { get; set; }
        

        public Client(IMapLoader mapLoader)
        {
            MapLoader = mapLoader;
            ServerModel = new GameModel(new Scene(), MapLoader.Load());
            ServerModel.StepFinished += OnStepFinished;
        }

        private void OnStepFinished(object sender, StepFinishedEventArgs args)
        {
            
        }

        public void AddActor(IActor actor)
        {
            ServerModel.Scene.Add(actor);
        }
        
        public void SetMap()
        {
            ServerModel.Map = MapLoader.Load();
        }
    }
}