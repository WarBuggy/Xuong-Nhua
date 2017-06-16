﻿using System;
using Xuong_Nhua.Pane.Base;
using Xuong_Nhua.InputControl;

namespace Xuong_Nhua.Pane.Material
{
    class PaneMaterialSelect : PaneBaseSelect
    {
        private PaneInputTextbox TxtName;

        public PaneMaterialSelect()
        {
            TxtName = new PaneInputTextbox("Name");
            TxtName.SetTextbox("");
            AddSelector(TxtName);
        }

        public override object[] GetParams()
        {
            return new object[] { TxtName.GetInputValue() };
        }
    }
}
