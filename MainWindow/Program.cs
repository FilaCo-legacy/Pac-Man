using System;
using System.Threading.Tasks;
using GameServer.GameMap;
using Gtk;

namespace MainWindow
{
    class Program
    {
        private const string defaultMapPath = @"DefaultMap.pcmap";
        
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();

            var app = new Application("org.MainWindow.MainWindow", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);
            
            var client = new Client(new MapFromFileLoader(defaultMapPath));
            
            var win = new MainWindow(client);
            //win.InitializeComponents();

            app.AddWindow(win);

            win.ShowAll();
            win.DeleteEvent += (obj, eventArgs) => { Application.Quit(); };
            Application.Run();
        }
    }
}