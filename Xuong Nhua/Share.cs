using System.Drawing;
using Xuong_Nhua.Database;
using System.Windows.Forms;

namespace Xuong_Nhua
{
    internal sealed class Share
    {
        // Fields
        public const string Version = "00001";
        public static Font FontApp = new Font("Arial Unicode MS", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
        public static Font FontTitle = new Font("Arial Unicode MS", 16f, FontStyle.Bold);

        public static Color ColBut = Color.DarkSeaGreen;
        public static Color ColDark = Color.DarkGreen;
        public static Color ColLight = Color.Honeydew;

        public static string dbName = "ctynhua";
        public static MySQLDB MySql = new MySQLDB("localhost", "user001", "nhan0206", dbName);

        public const int PANEUNITHEIGHT = 50;

        public static string confirmCaption = "Please confirm!";

        public static int MYSQL_CONSTRAINT_EXCEPTION = 1451;

        public static int INVENTORY_STATUS_IN_STOCK = 1;
        public static int INVENTORY_STATUS_SOLD = 2;
        public static int INVENTORY_STATUS_RETURNED = 3;

        // Methods
        /*
        public static string reFormatDate(string aDate)
        {
            string[] text = aDate.Split(new char[] { '/' });
            return (text[2] + "/" + text[1] + "/" + text[0]);
        }
        */

        /*
        public static string reFormatDouble(string strDouble)
        {
            string[] text = strDouble.Split(new char[] { ',' });
            if (text.Length == 1)
            {
                return strDouble;
            }
            if (text.Length == 2)
            {
                return (text[0] + "." + text[1]);
            }
            return "Error";
        }
        */

        public static void showWarningMessage(string message)
        {
            MessageBox.Show(null, message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        public static void showErrorMessage(string message)
        {
            MessageBox.Show(null, message, "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public static void showInfoMessage(string message)
        {
            MessageBox.Show(null, message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}
