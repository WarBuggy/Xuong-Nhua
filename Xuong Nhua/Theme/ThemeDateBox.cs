using System.Windows.Forms;

namespace Xuong_Nhua.Theme
{
    public class ThemeDateBox : DateTimePicker
    {
        // Methods
        public ThemeDateBox()
        {
            this.ForeColor = Share.ColDark;
            this.BackColor = Share.ColLight;
            this.Font = Share.FontApp;
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "dd-MM-yy";
        }

    }
}
