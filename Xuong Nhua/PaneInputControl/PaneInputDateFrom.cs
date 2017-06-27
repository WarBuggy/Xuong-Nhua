using System;
using System.Drawing;

namespace Xuong_Nhua.InputControl
{
    class PaneInputDateFrom : PaneInputDate
    {
        public PaneInputDateFrom(string inputCaption)
            : base(inputCaption)
        {
            ControlDefaultValue = DateTime.Now.AddYears(-1);
        }

        public new void SetDateBox(DateTime? initValue = null, bool required = true)
        {
            SetLabel(Caption);
            if (initValue == null)
            {
                InitValue = DateTime.Now.AddYears(-1);
            }
            else
            {
                InitValue = initValue;
            }
            isRequired = required;
            Datebox.Size = new Size(DefaultLength, 16);
            AddComponent(Datebox);
        }
    }
}
