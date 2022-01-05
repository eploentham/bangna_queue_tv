using bangna_queue_tv.object1;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace bangna_queue_tv.obgdb
{
    public class TQueueDB
    {
        public TQueue tque;
        ConnectDB conn;
        public TQueueDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            tque = new TQueue();
            tque.t_queue_id = "t_queue_id";
            tque.queue_id = "queue_id";
            tque.queue_date = "queue_date";
            tque.row_1 = "row_1";
            tque.queue_active = "queue_active";
            //que.row_1 = "row_1";
            tque.active = "active";
            tque.date_create = "date_create";
            tque.date_modi = "date_modi";
            tque.date_cancel = "date_cancel";
            tque.user_create = "user_create";
            tque.user_modi = "user_modi";
            tque.user_cancel = "user_cancel";
            tque.status_queue = "status_queue";
            tque.queue_name = "queue_name";
            tque.date_begin = "date_begin";
            tque.date_finish = "date_finish";
            tque.queue = "queue";
            tque.queue_current = "queue_current";
            tque.b_queue_date_id = "b_queue_date_id";
            tque.queue_call_id = "queue_call_id";

            tque.table = "t_queue";
            tque.pkField = "t_queue_id";

        }
        private void chkNull(TQueue p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.posi_id = int.TryParse(p.posi_id, out chk) ? chk.ToString() : "0";
            //p.posi_id = int.TryParse(p.posi_id, out chk) ? chk.ToString() : "0";
            p.queue_date = p.queue_date == null ? "" : p.queue_date;
            p.queue_name = p.queue_name == null ? "" : p.queue_name;
            p.queue_date = p.queue_date == null ? "" : p.queue_date;
            p.row_1 = p.row_1 == null ? "" : p.row_1;
            p.active = p.active == null ? "" : p.active;
            p.status_queue = p.status_queue == null ? "" : p.status_queue;
            p.queue_active = p.queue_active == null ? "" : p.queue_active;
            p.date_begin = p.date_begin == null ? "" : p.date_begin;
            p.date_finish = p.date_finish == null ? "" : p.date_finish;
            //p.queue = p.queue == null ? "" : p.queue;

            p.queue_id = long.TryParse(p.queue_id, out chk) ? chk.ToString() : "0";
            p.b_queue_date_id = long.TryParse(p.b_queue_date_id, out chk) ? chk.ToString() : "0";
            p.queue = long.TryParse(p.queue, out chk) ? chk.ToString() : "0";
            p.queue_current = long.TryParse(p.queue_current, out chk) ? chk.ToString() : "0";
            p.queue_call_id = long.TryParse(p.queue_call_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(TQueue p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);

            sql = "Insert Into " + tque.table + " set " +
                //" " + que.queue_date + "= now() " +
                //" " + que.row_1 + "='" + p.row_1 + "' " +
                " " + tque.active + "='1' " +
                //"," + que.staff_id + "='" + p.staff_id.Replace("'", "''") + "' " +
                //"," + que.status_queue + "='1' " +
                //"," + que.staff_name + "='" + p.staff_name.Replace("'", "''") + "' " +
                "," + tque.date_create + "= now() " +
                "," + tque.user_create + "='" + userId.Replace("'", "''") + "' " +
                "," + tque.queue_call_id + "='" + p.queue_call_id.Replace("'", "''") + "' " +
                "," + tque.queue_date + "='" + p.queue_date.Replace("'", "''") + "' " +
                "," + tque.row_1 + "='" + p.row_1.Replace("'", "''") + "' " +
                "," + tque.queue_active + "='" + p.queue_active.Replace("'", "''") + "' " +
                "," + tque.status_queue + "='" + p.status_queue.Replace("'", "''") + "' " +
                "," + tque.queue_name + "='" + p.queue_name.Replace("'", "''") + "' " +
                "," + tque.date_begin + "='" + p.date_begin.Replace("'", "''") + "' " +
                "," + tque.date_finish + "='" + p.date_finish.Replace("'", "''") + "' " +
                "," + tque.b_queue_date_id + "='" + p.b_queue_date_id.Replace("'", "''") + "' " +
                "," + tque.queue + "='" + p.queue.Replace("'", "''") + "' " +
                "," + tque.queue_current + "='" + p.queue_current.Replace("'", "''") + "' " +
                "";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String update(TQueue p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + tque.table + " Set " +
                " " + tque.queue_date + "='" + p.queue_date + "' " +
                //"," + que.row_1 + "='" + p.row_1 + "' " +
                "," + tque.active + "='" + p.active + "' " +
                "," + tque.date_modi + "=now() " +
                "," + tque.user_modi + "='" + userId.Replace("'", "''") + "' " +
                //"," + que.staff_name + "='" + p.staff_name.Replace("'", "''") + "' " +
                //"," + que.date_begin + "='" + p.date_begin.Replace("'", "''") + "' " +
                //"," + que.date_finish + "='" + p.date_finish.Replace("'", "''") + "' " +
                "," + tque.queue_date + "='" + p.queue_date.Replace("'", "''") + "' " +
                "," + tque.row_1 + "='" + p.row_1.Replace("'", "''") + "' " +
                "," + tque.queue_active + "='" + p.queue_active.Replace("'", "''") + "' " +
                "," + tque.status_queue + "='" + p.status_queue.Replace("'", "''") + "' " +
                "," + tque.queue_name + "='" + p.queue_name.Replace("'", "''") + "' " +
                "," + tque.date_begin + "='" + p.date_begin.Replace("'", "''") + "' " +
                "," + tque.date_finish + "='" + p.date_finish.Replace("'", "''") + "' " +
                "Where " + tque.pkField + "='" + p.t_queue_id + "'"
                ;

            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        
        public String insertQueue(TQueue p, String userId)
        {
            String re = "";

            if (p.queue_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }
            return re;
        }
        public String voidQueue(String tque_id, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            
            sql = "Update " + tque.table + " Set " +
                " " + tque.active + "='3' " +
                "," + tque.date_cancel + "=now() " +
                "," + tque.user_cancel + "='" + userId.Replace("'", "''") + "' " +
                "Where " + tque.pkField + "='" + tque_id + "'"
                ;

            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String voidQueueByQueDate(String que_date_id, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + tque.table + " Set " +
                " " + tque.active + "='3' " +
                "," + tque.date_cancel + "=now() " +
                "," + tque.user_cancel + "='" + userId.Replace("'", "''") + "' " +
                "Where " + tque.b_queue_date_id + "='" + que_date_id + "'"
                ;

            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String FinishAndNewQueue(String t_que_id, String que_date_id, String user_id, String queue_call_id)
        {
            String re = "", sql = "";
            TQueue stf1 = new TQueue();
            try
            {
                MySqlCommand cmd = new MySqlCommand("finishque_newque", conn.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("?t_que_id", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("?user_id1", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("?queue_date_id1", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("?queue_call_id", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("?ret", MySqlDbType.VarChar));
                cmd.Parameters["?t_que_id"].Direction = ParameterDirection.Input;
                cmd.Parameters["?t_que_id"].Value = t_que_id;
                cmd.Parameters["?queue_date_id1"].Direction = ParameterDirection.Input;
                cmd.Parameters["?queue_date_id1"].Value = que_date_id;
                cmd.Parameters["?user_id1"].Direction = ParameterDirection.Input;
                cmd.Parameters["?user_id1"].Value = user_id;
                cmd.Parameters["?queue_call_id"].Direction = ParameterDirection.Input;
                cmd.Parameters["?queue_call_id"].Value = queue_call_id;
                cmd.Parameters["?ret"].Direction = ParameterDirection.Output;
                conn.conn.Open();
                cmd.ExecuteNonQuery();
                re = ((String)cmd.Parameters["?ret"].Value).ToString();
                //MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //adap.Fill(dt);
                //stf1 = setQueue(dt);
                //stf1 = selectByPk(re);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            finally
            {
                conn.conn.Close();
            }
            return re;
        }
        public TQueue LockQueue(String queue_date_id, String t_que_id_old, String queue_call_id)
        {
            String re = "", sql = "";
            TQueue stf1 = new TQueue();
            try
            {
                MySqlCommand cmd = new MySqlCommand("lock_queue", conn.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("?t_que_id_old", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("?queue_call_id1", MySqlDbType.VarChar));
                //cmd.Parameters.Add(new MySqlParameter("?queue_date1", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("?b_queue_date_id1", MySqlDbType.VarChar));
                //cmd.Parameters.Add(new MySqlParameter("?ret", MySqlDbType.VarChar));
                cmd.Parameters["?t_que_id_old"].Direction = ParameterDirection.Input;
                cmd.Parameters["?t_que_id_old"].Value = t_que_id_old;
                cmd.Parameters["?queue_call_id1"].Direction = ParameterDirection.Input;
                cmd.Parameters["?queue_call_id1"].Value = queue_call_id;
                //cmd.Parameters["?queue_date1"].Direction = ParameterDirection.Input;
                //cmd.Parameters["?queue_date1"].Value = quedate;
                cmd.Parameters["?b_queue_date_id1"].Direction = ParameterDirection.Input;
                cmd.Parameters["?b_queue_date_id1"].Value = queue_date_id;
                //cmd.Parameters["?ret"].Direction = ParameterDirection.Output;
                conn.conn.Open();
                //cmd.ExecuteNonQuery();
                //re = ((String)cmd.Parameters["?ret"].Value).ToString();
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                stf1 = setQueue(dt);
                //stf1 = selectByPk(re);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
                new LogWriter("TQueueDB LockQueue " + sql);
                stf1.t_queue_id = "-1";
                stf1.queue_name = sql;
            }
            finally
            {
                conn.conn.Close();
            }
            return stf1;
        }
        public TQueue selectByPk(String tqueid)
        {
            String re = "0";
            int chk = 0;
            TQueue stf1 = new TQueue();
            DataTable dt = new DataTable();
            String sql = "select tque.*   " +
                "From " + tque.table + " tque " +
                "Where  tque." + tque.pkField + " = '" + tqueid + "'  " +
                "Order By " + tque.pkField + " asc limit 0,1";
            dt = conn.selectData(conn.conn, sql);
            stf1 = setQueue(dt);

            return stf1;
        }
        public TQueue selectQueNext(String queid, String date)
        {
            String re = "0";
            int chk = 0;
            TQueue stf1 = new TQueue();
            DataTable dt = new DataTable();
            String sql = "select tque.*   " +
                "From " + tque.table + " tque " +
                "Where  tque." + tque.pkField + " = '" + queid + "' and tque."+tque.queue_date+" = '"+date+"' " +
                "Order By " + tque.pkField+" asc limit 1,1";
            dt = conn.selectData(conn.conn, sql);
            stf1 = setQueue(dt);
            
            return stf1;
        }
        public TQueue selectQueNextByQueDateId(String quedateid)
        {
            String re = "0";
            int chk = 0;
            TQueue stf1 = new TQueue();
            DataTable dt = new DataTable();
            String sql = "select tque.*   " +
                "From " + tque.table + " tque " +
                "Where  tque." + tque.b_queue_date_id + " = '" + quedateid + "' " +
                "Order By " + tque.pkField + " asc limit 1,1";
            dt = conn.selectData(conn.conn, sql);
            stf1 = setQueue(dt);

            return stf1;
        }
        public TQueue setQueue(DataTable dt)
        {
            TQueue stf1 = new TQueue();
            if (dt.Rows.Count > 0)
            {
                stf1.t_queue_id = dt.Rows[0][tque.t_queue_id].ToString();
                stf1.queue_id = dt.Rows[0][tque.queue_id].ToString();
                stf1.queue_date = dt.Rows[0][tque.queue_date].ToString();
                stf1.row_1 = dt.Rows[0][tque.row_1].ToString();
                stf1.queue_active = dt.Rows[0][tque.queue_active].ToString();
                stf1.date_create = dt.Rows[0][tque.date_create].ToString();
                stf1.date_modi = dt.Rows[0][tque.date_modi].ToString();
                stf1.date_cancel = dt.Rows[0][tque.date_cancel].ToString();
                stf1.user_create = dt.Rows[0][tque.user_create].ToString();
                stf1.user_modi = dt.Rows[0][tque.user_modi].ToString();
                stf1.user_cancel = dt.Rows[0][tque.user_cancel].ToString();
                stf1.status_queue = dt.Rows[0][tque.status_queue].ToString();
                stf1.active = dt.Rows[0][tque.active].ToString();
                stf1.queue_name = dt.Rows[0][tque.queue_name].ToString();
                stf1.date_begin = dt.Rows[0][tque.date_begin].ToString();
                stf1.date_finish = dt.Rows[0][tque.date_finish].ToString();
                stf1.queue_current = dt.Rows[0][tque.queue_current].ToString();
                stf1.queue = dt.Rows[0][tque.queue].ToString();
                stf1.b_queue_date_id = dt.Rows[0][tque.b_queue_date_id].ToString();
                stf1.queue_call_id = dt.Rows[0][tque.queue_call_id].ToString();
            }
            else
            {
                setQueue1(stf1);
            }
            return stf1;
        }
        private TQueue setQueue1(TQueue stf1)
        {
            stf1.t_queue_id = "";
            stf1.queue_id = "";
            stf1.queue_date = "";
            stf1.queue_name = "";
            stf1.date_create = "";
            stf1.active = "";
            stf1.date_modi = "";
            stf1.date_cancel = "";
            stf1.user_create = "";
            stf1.user_modi = "";
            stf1.user_cancel = "";
            stf1.status_queue = "";
            stf1.date_begin = "";
            stf1.date_finish = "";
            stf1.queue_active = "";
            stf1.row_1 = "";
            stf1.queue_current = "";
            stf1.queue = "";
            stf1.b_queue_date_id = "";
            stf1.queue_call_id = "";
            return stf1;
        }
    }
}
