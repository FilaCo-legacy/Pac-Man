using GameServer;
using GameServer.GameMap;
using GameServer.GameObjects;
using Gdk;

namespace MainWindow
{
    public class Client
    {
        public GameModel ServerModel { get; }

        public MainWindow AppWindow { get; }
        
        public Client()
        {
            ServerModel = new GameModel(new Scene());
            AppWindow = new MainWindow();
        }

        public void AddActor(IActor actor)
        {
            ServerModel.Scene.Add(actor);
        }
    }
}