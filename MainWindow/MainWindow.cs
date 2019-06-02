using System;
using Cairo;
using GameServer;
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
        public MainWindow(Client client) : this(new Builder("MainWindow.glade"))
        {
            _client = client;
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
    }
}