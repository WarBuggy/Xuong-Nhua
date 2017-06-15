using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xuong_Nhua.Theme;
using System.Drawing;

namespace Xuong_Nhua.InputControl
{
    class PaneInputNumberbox : PaneInputControl
    {
        public ThemeNumberbox Numberbox { get; set; }

        private bool isRequired;
        private bool CanBeZero = false;

        public PaneInputNumberbox(string inputCaption)
            : base(inputCaption)
        {
            MODE = MODE_NUMBERBOX;
            Numberbox = new ThemeNumberbox();
            ControlDefaultValue = 0;
        }

        public override void RefreshData()
        {
            ResetValue();
        }

        public void SetNumberbox(int initValue, bool allowDecimal = false, bool required = true, int length = 100, bool canBeZero = false)
        {
            SetLabel(Caption);
            InitValue = initValue;
            isRequired = required;
            Numberbox.Size = new Size(length, 16);
            CanBeZero = canBeZero;
            if (!allowDecimal)
            {
                Numberbox.DecimalPlaces = 0;
            }
            AddComponent(Numberbox);
        }

        public override void ResetValue()
        {
            if (InitValue is int)
            {
                Numberbox.Value = (decimal)((int)InitValue);
            }
            else if (InitValue is short)
            {
                Numberbox.Value = (decimal)((short)InitValue);
            }
        }

        public override void SetNotReadyMessage()
        {
            NotReadyMessage = "must be inputed!";
        }

        public override void SetNewInitValue(object newValue)
        {
            InitValue = newValue;
            if (InitValue is int)
            {
                Numberbox.Value = (decimal)((int)InitValue);
            }
            else if (InitValue is short)
            {
                Numberbox.Value = (decimal)((short)InitValue);
            }
            else
            {
                Numberbox.Value = (decimal)((short)InitValue);
            }
        }

        public override bool IsReady()
        {
            // if the textbox does not required any input
            if (isRequired == false)
            {
                return true;
            }

            if (Numberbox.Value == 0 && CanBeZero == false)
            {
                return false;
            }
            return true;
        }

        public override object GetInputValue()
        {
            return Numberbox.Value;
        }

        public override void SetDefaultControlValue()
        {
            Numberbox.Value = (int)ControlDefaultValue;
            InitValue = ControlDefaultValue;
        }
    }
}
