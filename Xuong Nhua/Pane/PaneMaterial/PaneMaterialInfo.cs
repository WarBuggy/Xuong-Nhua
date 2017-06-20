using Xuong_Nhua.Pane.Base;

namespace Xuong_Nhua.Pane.Material
{
    public class PaneMaterialInfo : PaneBaseInfo
    {
        public PaneMaterialInfo()
        {
            AddLabel(new object[] { "Material", "Material(s): ", "0" });
        }

        public void SetInfo(int material)
        {
            UpdateLabelValue(new object[] { "Material", material });
        }
    }
}
