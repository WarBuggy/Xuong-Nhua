using System;
using Xuong_Nhua.Theme;
using System.Drawing;

namespace Xuong_Nhua.InputControl
{
    public class PaneInputDate : PaneInputControl
    {
        public ThemeDateBox Datebox { get; set; }
        public bool isRequired;
        public static int DefaultLength = 100;

        public PaneInputDate(string inputCaption)
            : base(inputCaption)
        {
            MODE = MODE_TEXTBOX;
            Datebox = new ThemeDateBox();
            ControlDefaultValue = DateTime.Now;
        }

        public override void RefreshData()
        {
            ResetValue();
        }

        public void SetDateBox(DateTime? initValue = null, bool required = true)
        {
            SetLabel(Caption);
            if (initValue == null)
            {
                InitValue = DateTime.Now;
            }
            else
            {
                InitValue = initValue;
            }
            isRequired = required;
            Datebox.Size = new Size(DefaultLength, 16);
            AddComponent(Datebox);
        }

        public override void ResetValue()
        {
            if (InitValue is DateTime)
            {
                Datebox.Value = Convert.ToDateTime(InitValue);
            }
            else
            {
                Datebox.Value = DateTime.ParseExact(InitValue.ToString(), "dd-MM-yy", null);
            }
        }

        public override void SetNotReadyMessage()
        {
            NotReadyMessage = "must be inputed!";
        }

        public override void SetNewInitValue(object newValue)
        {
            InitValue = newValue;
            Datebox.Value = DateTime.ParseExact(InitValue.ToString(), "dd-MM-yy", null);
        }

        public override bool IsReady()
        {
            // if the textbox does not required any input
            if (isRequired == false)
            {
                return true;
            }

            // if the textbox requires input but has no input text
            if (Datebox.Value == null)
            {
                return false;
            }
            return true;
        }

        public override object GetInputValue()
        {
            return Datebox.Value.ToString("yyyy-MM-dd");
        }

        public override void SetDefaultControlValue()
        {
            Datebox.Value = (DateTime)ControlDefaultValue;
            InitValue = (DateTime)ControlDefaultValue;
        }
    }
}
