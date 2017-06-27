using Xuong_Nhua.Pane.Base;

namespace Xuong_Nhua.Pane.Worker
{
    public class PaneWorkerInfo : PaneBaseInfo
    {
        public PaneWorkerInfo()
        {
            AddLabel(new object[] { "Worker", "Worker(s): ", "0" });
            AddLabel(new object[] { "Salary", "Total Salary: ", "0" });
        }

        public void SetInfo(int worker, int salary)
        {
            UpdateLabelValue(new object[] { "Worker", worker });
            UpdateLabelValue(new object[] { "Salary", salary });
        }
    }
}