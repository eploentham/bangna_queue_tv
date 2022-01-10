using bangna_queue_tv.object1;
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
using System.Windows.Forms;

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
        public MySqlConnection connIm, connEx, conn;
        public MySqlConnection connNoClose;

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
        public Staff user;

        public String pathSSO = "";
        public ConnectDB(InitConfig initc)
        {
            //iniFile = new IniFile("bangna_queue_tv.ini");

            conn = new MySqlConnection();
            connIm = new MySqlConnection();
            connEx = new MySqlConnection();
            connNoClose = new MySqlConnection();

            conn.ConnectionString = "Server=" + initc.hostDB + ";Database=" + initc.nameDB + ";Uid=" + initc.userDB + ";Pwd=" + initc.passDB +
                ";port = " + initc.portDB + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none; convert zero datetime=True; ";
            connNoClose.ConnectionString = "Server=" + initc.hostDB + ";Database=" + initc.nameDB + ";Uid=" + initc.userDB + ";Pwd=" + initc.passDB +
                ";port = " + initc.portDB + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none; convert zero datetime=True; ";
            connIm.ConnectionString = "Server=" + initc.hostDBIm + ";Database=" + initc.nameDBIm + ";Uid=" + initc.userDBIm + ";Pwd=" + initc.passDBIm +
                ";port = " + initc.portDBIm + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none; convert zero datetime=True; ";
            connEx.ConnectionString = "Server=" + initc.hostDBEx + ";Database=" + initc.nameDBEx + ";Uid=" + initc.userDBEx + ";Pwd=" + initc.passDBEx +
                ";port = " + initc.portDBEx + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none; convert zero datetime=True; ";
            user = new Staff();

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
        public DataTable selectData(MySqlConnection con, String sql)
        {
            DataTable toReturn = new DataTable();

            MySqlCommand comMainhis = new MySqlCommand();
            comMainhis.CommandText = sql;
            comMainhis.CommandType = CommandType.Text;
            comMainhis.Connection = con;
            MySqlDataAdapter adapMainhis = new MySqlDataAdapter(comMainhis);
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                adapMainhis.Fill(toReturn);
                //return toReturn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Message" + ex.Message + "\n" + sql, "Error");
                if (con.State == ConnectionState.Open)
                {
                    //con.Close();
                }
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                con.Close();
                comMainhis.Dispose();
                adapMainhis.Dispose();
            }
            return toReturn;
        }
        public String ExecuteNonQuery(MySqlConnection con, String sql)
        {
            String toReturn = "";

            MySqlCommand com = new MySqlCommand();
            com.CommandText = sql;
            com.CommandType = CommandType.Text;
            com.Connection = con;
            try
            {
                con.Open();
                _rowsAffected = com.ExecuteNonQuery();
                //_rowsAffected = (int)com.ExecuteScalar();
                toReturn = sql.Substring(0, 1).ToLower() == "i" ? com.LastInsertedId.ToString() : _rowsAffected.ToString();
                if (sql.IndexOf("Insert Into Visit") >= 0)        //old program
                {
                    toReturn = _rowsAffected.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                con.Close();
                com.Dispose();
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
