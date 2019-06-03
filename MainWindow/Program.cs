using System;
using System.Threading.Tasks;
using GameServer.GameMap;
using Gtk;

namespace MainWindow
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();

            var app = new Application("org.MainWindow.MainWindow", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);
            
            var client = new Client();
            
            var win = new MainWindow();

            app.AddWindow(win);

            win.ShowAll();
            win.DeleteEvent += (obj, eventArgs) => { Application.Quit(); };
            client.ServerModel.StepFinished += win.OnStepFinished;
            client.ServerModel.ExecuteAsync();
            Application.Run();
        }
    }
}