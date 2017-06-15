using MySql.Data.MySqlClient;
using System.Data;

namespace Xuong_Nhua.Database
{
    public class MySQLDB
    {
        // Fields
        private string strDatabase;
        private string strPass;
        private string strServer;
        private string strUserID;

        // Methods
        public MySQLDB(string server, string uid, string pass)
        {
            this.strServer = server;
            this.strUserID = uid;
            this.strPass = pass;
        }

        public MySQLDB(string server, string uid, string pass, string db)
        {
            this.strServer = server;
            this.strUserID = uid;
            this.strPass = pass;
            this.strDatabase = db;
        }

        private MySqlConnection getConnection()
        {
            return new MySqlConnection("server=" + this.strServer + ";uid=" + this.strUserID + ";password=" + this.strPass + ";database=" + this.strDatabase + ";Charset=utf8;");
        }

        public int ExeCommand(string query)
        {
            int returnVal;
            MySqlConnection connMySQLConn = getConnection();
            try
            {
                MySqlCommand command = new MySqlCommand(query, connMySQLConn);
                connMySQLConn.Open();
                command.ExecuteNonQuery();
                connMySQLConn.Close();
                command.Dispose();
                returnVal = 0;
            }
            catch (MySqlException exception1)
            {
                if (exception1.Number == Share.MYSQL_CONSTRAINT_EXCEPTION)
                {
                    Share.showErrorMessage("This record cannot be delete because it is required somewhere else." + System.Environment.NewLine + exception1.Message);
                }
                else
                {
                    throw exception1;
                }
                returnVal = exception1.Number;
            }
            finally
            {
                connMySQLConn.Dispose();
            }
            return returnVal;
        }

        public int ExeCommand(MySqlCommand command)
        {
            int returnVal;
            MySqlConnection connMySQLConn = getConnection();
            try
            {
                command.Connection = connMySQLConn;
                connMySQLConn.Open();
                command.ExecuteNonQuery();
                connMySQLConn.Close();
                command.Dispose();
                returnVal = 0;
            }
            catch (MySqlException exception1)
            {
                throw exception1;
            }
            finally
            {
                connMySQLConn.Dispose();
            }
            return returnVal;
        }

        public DataTable GetDataTable(string query)
        {
            MySqlConnection connMySQLConn = getConnection();
            DataTable getDataTable = new DataTable();
            try
            {
                connMySQLConn.Open();
                MySqlDataAdapter adMySQLAdapter = new MySqlDataAdapter(query, connMySQLConn);
                adMySQLAdapter.Fill(getDataTable);
                connMySQLConn.Close();
                adMySQLAdapter.Dispose();
            }
            catch (MySqlException exception1)
            {
                throw exception1;
            }
            finally
            {
                connMySQLConn.Dispose();
            }
            return getDataTable;
        }

        public DataTable GetDataTable(MySqlCommand command)
        {
            MySqlConnection connMySQLConn = getConnection();
            DataTable getDataTable = new DataTable();
            try
            {
                connMySQLConn.Open();
                command.Connection = connMySQLConn;
                MySqlDataAdapter adMySQLAdapter = new MySqlDataAdapter(command);
                adMySQLAdapter.Fill(getDataTable);
                connMySQLConn.Close();
                adMySQLAdapter.Dispose();
            }
            catch (MySqlException exception1)
            {
                throw exception1;
            }
            finally
            {
                connMySQLConn.Dispose();
            }
            return getDataTable;
        }
    }

}
