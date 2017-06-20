using System.Windows.Forms;

namespace Xuong_Nhua.Theme
{
    public partial class ThemeButton : UserControl
    {
        public ThemeButton()
        {
            InitializeComponent();
            StyleButton();
        }

        private void StyleButton()
        {
            Button.Cursor = Cursors.Hand;
            Button.BackColor = Share.ColBut;
            Button.UseVisualStyleBackColor = false;
            Button.Font = Share.FontApp;
        }

        public void SetButtonText(string text)
        {
            Button.Text = text;
        }

        public void SetButtonHotkey(string key)
        {
        }

        public Button GetButton()
        {
            return Button;
        }
    }
}
