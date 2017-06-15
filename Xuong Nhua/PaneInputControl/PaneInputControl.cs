using System;
using System.Windows.Forms;
using Xuong_Nhua.Theme;

namespace Xuong_Nhua.InputControl
{
    public abstract partial class PaneInputControl : UserControl
    {
        private ThemeLabelInfo Label = new ThemeLabelInfo();
        public static int MODE_COMBO = 1;
        public static int MODE_TEXTBOX = 2;
        public static int MODE_NUMBERBOX = 3;
        public static int MODE_DATEBOX = 4;
        public int MODE = 0;

        public string NotReadyMessage { get; set; }
        public string Caption { get; set; }
        private string NotReadyError;
        public object InitValue { get; set; }
        public object ControlDefaultValue { get; set; }
        public Boolean NeedReset { get; set; }
        public Boolean NeedValidate { get; set; }

        public PaneInputControl(string inputCaption, bool needValidate = true)
        {
            InitializeComponent();
            Caption = inputCaption;
            NeedValidate = needValidate;
            SetLabel(Caption);
            Label.Anchor = AnchorStyles.Left;
            Pane.Controls.Add(Label);
            SetNotReadyMessage();
            NeedReset = true;
        }

        public ThemeLabelInfo GetLabel()
        {
            return Label;
        }

        public void SetLabel(string LabelText)
        {
            Label.Text = LabelText;
            NotReadyError = Caption + " " + NotReadyMessage;
        }

        public void AddComponent(Control control)
        {
            Pane.Controls.Add(control);
        }

        public abstract void RefreshData();

        public abstract void ResetValue();

        public abstract void SetNotReadyMessage();

        public string GetNotReadyError()
        {
            return NotReadyError;
        }

        public abstract bool IsReady();

        public abstract object GetInputValue();

        public abstract void SetNewInitValue(object newValue);

        public abstract void SetDefaultControlValue();
    }
}
