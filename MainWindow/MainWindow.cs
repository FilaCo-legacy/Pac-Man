using System;
using Cairo;
using GameServer;
using GameServer.GameMap;
using Gdk;
using GLib;
using Gtk;
using Application = GLib.Application;
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

        private void OnStepFinished(object sender, StepFinishedEventArgs args)
        {
            
        }

        public void SetPacManMap(IMap pacManMap)
        {
            MainSheet_PacManSheet.PacManMap = pacManMap;
        }
    }
}