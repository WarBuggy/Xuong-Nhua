using System;
using Xuong_Nhua.Pane.Base;

namespace Xuong_Nhua.Pane.Product
{
    public class PaneProductInfo : PaneBaseInfo
    {
        public PaneProductInfo()
        {
            AddLabel(new object[] { "Product", "Product(s): ", "0" });
        }

        public void SetInfo(int product)
        {
            UpdateLabelValue(new object[] { "Product", product });
        }
    }
}
