using System;
using GameServer;
using GLib;
using MainWindow.Render;
using Application = Gtk.Application;

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

            win.ShowAll();
            win.DeleteEvent += (obj, eventArgs) => { Application.Quit(); };
            
            win.AddRenderer(new MapRenderer());
            win.AddRenderer(new FoodRenderer());
            win.AddRenderer(new PacManRenderer());

            var gameModel = new GameModel(new Scene(), win);

            gameModel.ExecuteAsync();
            Application.Run();
        }
    }
}