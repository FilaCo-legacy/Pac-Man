using System;
using Cairo;
using GameServer;
using GameServer.GameMap;
using GameServer.GameObjects;
using Gdk;
using GLib;
using Gtk;
using Application = GLib.Application;
using Key = Gdk.Key;
using UI = Gtk.Builder.ObjectAttribute;
using Window = Gtk.Window;

namespace MainWindow
{
    public partial class MainWindow : Window
    {
        public MainWindow() : this(new Builder("MainWindow.glade"))
        {
            InitializeComponents();
        }

        private MainWindow(Builder builder) : base(builder.GetObject("MainWindow").Handle)
        {
            builder.Autoconnect(this);
        }

        private void ExitButton_Clicked(object sender, EventArgs args)
        {
            Close();
        }

        public void OnStepFinished(object sender, StepFinishedEventArgs args)
        {
            
            QueueDraw();
        }

        [ConnectBefore]
        private void MainWindow_KeyPressed(object sender, KeyPressEventArgs args)
        {
            switch (args.Event.Key)
            {
               case Key.Left:
                    PacMan.GetInstance.Direction = MoveDirection.Left;
                    break;
               case Key.Up:
                    PacMan.GetInstance.Direction = MoveDirection.Up;
                    break;
               case Key.Down:
                    PacMan.GetInstance.Direction = MoveDirection.Down;
                    break;
               case Key.Right:
                    PacMan.GetInstance.Direction = MoveDirection.Right;
                    break;
            }
        }
    }
}