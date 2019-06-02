using Cairo;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using Window = Gtk.Window;

namespace MainWindow
{
    public partial class MainWindow
    {
        private PacManSheet MainSheet_PacManSheet;
        private StatusBarSheet StatusBar_StatusBarSheet;
        [UI] 
        private Box GameSheet_Box;
        [UI]
        private Button NewGame_Button;
        [UI]
        private Button PauseResume_Button;
        [UI]
        private Button Exit_Button;

        private void InitializeComponents()
        {
            InitializeMainSheet();
            InitializeStatusBar();
            Exit_Button.Clicked += ExitButton_Clicked;
        }

        private void InitializeMainSheet()
        {
            MainSheet_PacManSheet = new PacManSheet();
            GameSheet_Box.Add(MainSheet_PacManSheet);
        }

        private void InitializeStatusBar()
        {
            StatusBar_StatusBarSheet = new StatusBarSheet();
            GameSheet_Box.Add(StatusBar_StatusBarSheet);
        }
    }
}