using System;
using System.Drawing;

namespace Xuong_Nhua.InputControl
{
    class PaneInputDateFrom : PaneInputDate
    {
        private int MonthDifference = 0;

        public PaneInputDateFrom(string inputCaption, int months)
    : base(inputCaption)
        {
            MonthDifference = months;
            ControlDefaultValue = DateTime.Now.AddMonths(MonthDifference);
        }

        public new void SetDateBox(DateTime? initValue = null, bool required = true)
        {
            SetLabel(Caption);
            if (initValue == null)
            {
                InitValue = DateTime.Now.AddMonths(MonthDifference);
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
