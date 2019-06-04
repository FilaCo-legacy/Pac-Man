using System;
using System.Threading;
using GameServer;
using GLib;
using MainWindow.Render;
using Application = Gtk.Application;
using Task = System.Threading.Tasks.Task;
using Thread = GLib.Thread;

namespace MainWindow
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();

            var app = new Application("org.MainWindow.MainWindow", ApplicationFlags.None);
            app.Register(Cancellable.Current);

            var win = new MainWindow();

            app.AddWindow(win);
            
            var gameModel = new GameModel(new Scene(), win);

            win.ShowAll();
            win.DeleteEvent += (obj, eventArgs) =>
            {
                Application.Quit();
            };
            
            win.AddRenderer(new MapRenderer());
            win.AddRenderer(new FoodRenderer());
            win.AddRenderer(new PacManRenderer());
            win.AddRenderer(new BlinkyRenderer());

            var gameServer = new System.Threading.Thread(gameModel.Execute) {IsBackground = true};

            //System.Threading.Thread.CurrentThread.Priority = ThreadPriority.Highest;
            
            gameServer.Start();
            Application.Run();
        }
    }
}