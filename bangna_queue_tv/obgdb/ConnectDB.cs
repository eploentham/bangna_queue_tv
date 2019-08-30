using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bangna_queue_tv
{
    public class ConnectDB
    {
        public String Unamelogin = "";
        public OleDbConnection cntemp = new OleDbConnection();
        public int portnumber = 0;
        public String UName = "", User1 = "", SS = "";
        public OleDbConnection _mainConnection = new OleDbConnection();
        public int _rowsAffected = 0;
        public SqlInt32 _errorCode = 0;
        public Boolean _isDisposed = false;
        public MySqlConnection conn, connMainHIS1;
        private String hostname = "";
        private IniFile iniFile;
        public String hostDB = "", databaseNameMainHIS1 = "";
        public String hostName = "", hostNameMainHIS1 = "";
        public String userDB = "", userNameMainHIS1 = "";
        public String passwordDB = "", passwordMainHIS1 = "";
        public String databaseNameBua = "";
        public String hostNameBua = "";
        public String userNameBua = "";
        public String passwordBua = "";
        public String server = "";
        public String isBranch = "";
        private LogWriter lw;
        public String pathLabEx = "";

        public String pathSSO = "";
        public ConnectDB()
        {
            iniFile = new IniFile("bangna_queue_tv.ini");

            hostDB = iniFile.Read("database_name");
            hostName = iniFile.Read("host_name");
            userDB = iniFile.Read("user_db");            
            passwordDB = iniFile.Read("password_db");
            conn = new MySqlConnection();

            conn.ConnectionString = "Server=" + this.hostName + ";Database=" + hostDB + ";Uid=" + userDB + ";Pwd=" + passwordDB + ";port = 3306;Connection Timeout = 300;default command timeout=0;";

        }
        
        public String GetConfig(String key)
        {

            AppSettingsReader _configReader = new AppSettingsReader();
            // Set connection string of the sqlconnection object
            return _configReader.GetValue(key, "".GetType()).ToString();
        }
        public DataTable selectData(String sql)
        {
            DataTable toReturn = new DataTable();
            
            MySqlCommand comMainhis = new MySqlCommand();
            comMainhis.CommandText = sql;
            comMainhis.CommandType = CommandType.Text;
            comMainhis.Connection = conn;
            MySqlDataAdapter adapMainhis = new MySqlDataAdapter(comMainhis);
            try
            {
                conn.Open();
                adapMainhis.Fill(toReturn);
                //return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                conn.Close();
                comMainhis.Dispose();
                adapMainhis.Dispose();
            }
            
            return toReturn;
        }
        
        
        public String ExecuteNonQuery(String sql)
        {
            String toReturn = "";
            
            MySqlCommand comMainhis = new MySqlCommand();
            comMainhis.CommandText = sql;
            comMainhis.CommandType = CommandType.Text;
            comMainhis.Connection = conn;
            try
            {
                conn.Open();
                _rowsAffected = comMainhis.ExecuteNonQuery();
                toReturn = _rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                conn.Close();
                comMainhis.Dispose();
            }
            
            return toReturn;
        }
        
        public String OpenConnection()
        {
            String toReturn = "";
            if ((hostname == "mainhis") || (hostname == "bangna"))
            {
                MySqlCommand comMainhis = new MySqlCommand();
                //comMainhis.CommandText = sql;
                comMainhis.CommandType = CommandType.Text;
                comMainhis.Connection = conn;
                try
                {
                    conn.Open();
                    //_rowsAffected = comMainhis.ExecuteNonQuery();
                    //toReturn = _rowsAffected.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception("ExecuteNonQuery::Error occured.", ex);
                    toReturn = ex.Message;
                }
                finally
                {
                    //_mainConnection.Close();
                    //comMainhis.Dispose();
                }
            }
            else
            {
                OleDbCommand cmdToExecute = new OleDbCommand();
                //cmdToExecute.CommandText = sql;
                cmdToExecute.CommandType = CommandType.Text;
                cmdToExecute.Connection = _mainConnection;
                try
                {
                    _mainConnection.Open();
                    //_rowsAffected = cmdToExecute.ExecuteNonQuery();
                    //toReturn = _rowsAffected.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception("ExecuteNonQuery::Error occured.", ex);
                    toReturn = ex.Message;
                }
                finally
                {
                    //_mainConnection.Close();
                    //cmdToExecute.Dispose();
                }
            }
            return toReturn;
        }
        public void CloseConnection()
        {
            conn.Close();
        }
    }
}
