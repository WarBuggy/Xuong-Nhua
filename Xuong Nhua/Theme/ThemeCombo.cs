﻿using System.Data;
using System.Windows.Forms;

namespace Xuong_Nhua.Theme
{
    public class ThemeCombo : ComboBox
    {
        // Fields
        private string allSelect = "All";
        private static string plsSelect = "Please select!";

        public static int ONE_SELECT_MODE = 0;
        public static int ALL_SELECT_MODE = 1;
        public static int PREV_SELECT_MODE = 2;

        // Methods
        public ThemeCombo()
        {
            this.BackColor = Share.ColLight;
            this.ForeColor = Share.ColDark;
            this.FormattingEnabled = true;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void Fill(string sql, int mode, string ValueName, string MemberName)
        {
            int preSelectedIndex;
            if (this.SelectedIndex >= 0)
            {
                preSelectedIndex = this.SelectedIndex;
            }
            else
            {
                preSelectedIndex = 0;
            }
            this.DataSource = null;
            this.Items.Clear();

            string temp = "select 0 as sortcol, null as ";
            if (mode == ONE_SELECT_MODE)
            {
                temp = temp + ValueName + ", '" + plsSelect + "' as " + MemberName;
            }
            else if (mode == ALL_SELECT_MODE)
            {
                temp = temp + ValueName + ", '" + allSelect + "' as " + MemberName;
            }
            if (sql.Length > 0)
            {
                temp = temp + " UNION " + sql + " order by sortcol, `" + MemberName + "`";
            }
            DataTable dt = Share.MySql.GetDataTable(temp);
            this.DataSource = dt;
            this.ValueMember = ValueName;
            this.DisplayMember = MemberName;

            if (preSelectedIndex > 0 && preSelectedIndex < dt.Rows.Count)
            {
                this.SelectedIndex = preSelectedIndex;
            }
        }

        public int GetSelectedIndex()
        {
            return this.SelectedIndex;
        }
    }
}
