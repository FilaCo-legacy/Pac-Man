using Cairo;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using Window = Gtk.Window;

namespace MainWindow
{
    public partial class MainWindow
    {
        public PacManSheet MainSheet_PacManSheet;
        private StatusBarSheet StatusBar_StatusBarSheet;
        
        [UI] 
        private Box GameBox_GtkBox;
        
        [UI]
        private Button ExitButton_GtkButton;

        private void InitializeComponents()
        {
            InitializeMainSheet();
            InitializeStatusBar();
            ExitButton_GtkButton.Clicked += ExitButton_Clicked;
            KeyPressEvent += new KeyPressEventHandler(MainWindow_KeyPressed);
        }

        private void InitializeMainSheet()
        {
            MainSheet_PacManSheet = new PacManSheet();

            GameBox_GtkBox.Add(MainSheet_PacManSheet);
            GameBox_GtkBox.SetChildPacking(MainSheet_PacManSheet, true, true, 0, PackType.Start);
        }

        private void InitializeStatusBar()
        {
            StatusBar_StatusBarSheet = new StatusBarSheet();
            //GameBox_GtkBox.Add(StatusBar_StatusBarSheet);
        }
    }
}