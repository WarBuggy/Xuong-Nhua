using Xuong_Nhua.Pane.Base;
using System.Drawing;

namespace Xuong_Nhua.Pane.Worker
{
    public class PaneWorkerInfo : PaneBaseInfo
    {
        public PaneWorkerInfo()
        {
            AddLabel(new object[] { "Worker", "Worker(s): ", "0" });
            AddLabel(new object[] { "Salary", "Total Salary: ", "0", Color.DarkMagenta });
        }

        public void SetInfo(int worker, int salary)
        {
            UpdateLabelValue(new object[] { "Worker", worker });
            UpdateLabelValue(new object[] { "Salary", salary });
        }
    }
}