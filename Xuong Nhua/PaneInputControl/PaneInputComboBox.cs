using System;
using Xuong_Nhua.Theme;
using System.Drawing;

namespace Xuong_Nhua.InputControl
{
    public class PaneInputComboBox : PaneInputControl
    {
        private ThemeCombo ComboBox = new ThemeCombo();
        private string sql = "";
        private int mode = -1;
        private string valueName = "";
        private string memberName = "";

        public PaneInputComboBox(string inputCaption, bool needValidate = true)
            : base(inputCaption)
        {
            NeedValidate = needValidate;
            MODE = MODE_COMBO;
            ControlDefaultValue = null;
        }

        public ThemeCombo GetComboBox()
        {
            return ComboBox;
        }

        public override void RefreshData()
        {
            RefreshCombo();
        }

        public void SetComboBox(string inputSql, int inputMode, string inputValueName, string inputMemberName, object initialValue = null, bool addControl = true)
        {
            InitValue = initialValue;
            SetLabel(Caption);

            sql = inputSql;
            mode = inputMode;
            valueName = inputValueName;
            memberName = inputMemberName;
            ComboBox.Fill(sql, mode, valueName, memberName);

            if (addControl == true)
            {
                AddComponent(ComboBox);
            }
        }

        public void RefreshCombo()
        {
            ComboBox.Fill(sql, mode, valueName, memberName);
        }

        public int GetCurrentIndex()
        {
            return ComboBox.SelectedIndex;
        }

        public void SetSelectedIndex(int index)
        {
            ComboBox.SelectedIndex = index;
        }

        public object GetSelectedValue()
        {
            return ComboBox.SelectedValue;
        }

        public override void ResetValue()
        {
            if (NeedReset == true)
            {
                if (InitValue != null)
                {
                    ComboBox.SelectedValue = InitValue;
                }
                else
                {
                    ComboBox.SelectedIndex = 0;
                }
            }
        }

        public override void SetNotReadyMessage()
        {
            NotReadyMessage = "must be selected!";
        }

        public override bool IsReady()
        {
            if (ComboBox.SelectedIndex <= 0 && NeedValidate == true)
            {
                return false;
            }
            return true;
        }

        public override object GetInputValue()
        {
            return ComboBox.SelectedValue;
        }

        public override void SetNewInitValue(object newValue)
        {
            InitValue = newValue;
            ComboBox.SelectedValue = InitValue;
        }

        public override void SetDefaultControlValue()
        {
            if (ControlDefaultValue != null)
            {
                ComboBox.SelectedValue = ControlDefaultValue;
            }
            else
            {
                ComboBox.SelectedIndex = 0;
            }
            InitValue = ControlDefaultValue;
        }
    }
}
