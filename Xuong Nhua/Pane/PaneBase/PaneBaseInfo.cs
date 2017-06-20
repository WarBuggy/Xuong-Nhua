using System;
using System.Drawing;
using System.Windows.Forms;
using Xuong_Nhua.Theme;

namespace Xuong_Nhua.Pane.Base
{
    public partial class PaneBaseInfo : UserControl
    {
        public PaneBaseInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method allows information labels to be added to the information pane control
        /// <para>
        /// 1st argument is the label name, which is used to identify the label after
        /// </para>
        /// <para>
        /// 2nd argument is the text of the label
        /// </para>
        /// <para>
        /// 3rd argument is the inital value
        /// <para>
        /// </para>
        /// 4th argument is optional and let the label forecolor to be defined
        /// </para>
        /// </summary>
        public void AddLabel(object[] args)
        {
            if (args.Length < 1 || args.Length > 4)
            {
                Share.showErrorMessage("Invalid number of parameters for AddLabel");
                return;
            }
            string labelName = args[0].ToString();
            string labelText = args[1].ToString();
            string initValue = args[2].ToString();

            ThemeLabelInfo label = new ThemeLabelInfo();
            label.Name = labelName + "Label";
            label.Text = labelText;
            if (args.Length == 4)
            {
                label.ForeColor = (Color)args[3];
            }
            Pane.Controls.Add(label);

            label = new ThemeLabelInfo();
            label.Name = labelName;
            label.Text = initValue;
            if (args.Length == 4)
            {
                label.ForeColor = (Color)args[3];
            }
            Pane.Controls.Add(label);
        }

        public Label GetLabel(string labelName)
        {
            try
            {
                return (Label)Pane.Controls[labelName];
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// This method allows information label contents to be updated
        /// <para>
        /// 1st argument is the label name, which is used to identify the label
        /// </para>
        /// <para>
        /// 2nd argument is the new value of the label
        /// </para>
        /// <para>
        /// 3th argument is optional and let the label forecolor to be re-defined
        /// </para>
        /// </summary>
        public void UpdateLabelValue(object[] args)
        {
            if (args.Length < 1 || args.Length > 3)
            {
                Share.showErrorMessage("Invalid number of parameters for UpdateLabelValue");
                return;
            }
            string labelName = args[0].ToString();
            string newValue = args[1].ToString();
            try
            {
                GetLabel(labelName).Text = String.Format("{0:#,0.########}", double.Parse(newValue)); ;
                if (args.Length == 3)
                {
                    GetLabel(labelName).ForeColor = (Color)args[2];
                }
            }
            catch (Exception e)
            {
                Share.showErrorMessage(e.Message);
            }
        }
    }
}
