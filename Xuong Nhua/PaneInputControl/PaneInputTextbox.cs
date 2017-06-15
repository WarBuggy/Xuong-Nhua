using System;
using Xuong_Nhua.Theme;
using System.Drawing;

namespace Xuong_Nhua.InputControl
{
    public class PaneInputTextbox : PaneInputControl
    {
        public ThemeTextbox Textbox { get; set; }

        private bool isRequired;

        public PaneInputTextbox(string inputCaption)
            : base(inputCaption)
        {
            MODE = MODE_TEXTBOX;
            Textbox = new ThemeTextbox();
            ControlDefaultValue = "";
        }

        public override void RefreshData()
        {
            ResetValue();
        }

        public void SetTextbox(string initValue, bool required = true, int length = 150)
        {
            SetLabel(Caption);
            InitValue = initValue;
            isRequired = required;
            Textbox.Size = new Size(length, 16);
            AddComponent(Textbox);
        }

        public override void ResetValue()
        {
            Textbox.Text = InitValue.ToString();
        }

        public override void SetNotReadyMessage()
        {
            NotReadyMessage = "must be inputed!";
        }

        public override void SetNewInitValue(object newValue)
        {
            InitValue = newValue;
            Textbox.Text = InitValue.ToString();
        }

        public override bool IsReady()
        {
            // if the textbox does not required any input
            if (isRequired == false)
            {
                return true;
            }

            // if the textbox requires input but has no input text
            if (string.IsNullOrEmpty(Textbox.Text.Trim()))
            {
                return false;
            }
            return true;
        }

        public override object GetInputValue()
        {
            return Textbox.Text.Trim();
        }

        public override void SetDefaultControlValue()
        {
            Textbox.Text = ControlDefaultValue.ToString();
            InitValue = ControlDefaultValue.ToString();
        }
    }
}
