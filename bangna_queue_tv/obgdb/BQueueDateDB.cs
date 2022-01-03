using bangna_queue_tv.object1;
using C1.Win.C1Input;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bangna_queue_tv.obgdb
{
    public class BQueueDateDB
    {
        public BQueueDate bque;
        ConnectDB conn;
        public List<BQueueDate> lStf;
        public BQueueDateDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            bque = new BQueueDate();
            bque.b_queue_date_id = "b_queue_date_id";
            bque.queue_id = "queue_id";
            bque.queue_date = "queue_date";
            bque.queue_current = "queue_current";//ตอนนี้ ถึงคิว ที่เท่าไร จะได้รู้ว่าต้องรอ อีกกี่คิว
            bque.queue = "queue";//คิวที่กดได้ เลขที่คิว

            bque.table = "b_queue_date";
            bque.pkField = "b_queue_date_id";

            lStf = new List<BQueueDate>();

        }
        private void chkNull(BQueueDate p)
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
            p.queue_current = p.queue_current == null ? "" : p.queue_current;
            p.queue = p.queue == null ? "" : p.queue;

            p.queue_id = long.TryParse(p.queue_id, out chk) ? chk.ToString() : "0";
            
        }
        public String insert(BQueueDate p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            
            sql = "Insert Into " + bque.table + " set " +
                " " + bque.queue_date + "='" + p.queue_date + "' " +
                "," + bque.queue_current + "='" + p.queue_current + "' " +
                "," + bque.queue + "='" + p.queue + "' " +
                "," + bque.queue_id + "='" + p.queue_id.Replace("'", "''") + "' " +
                
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
        public String update(BQueueDate p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + bque.table + " Set " +
                " " + bque.queue_date + "='" + p.queue_date + "' " +
                //"," + bque.queue_current + "='" + p.queue_current + "' " +
                //"," + bque.queue + "='" + p.queue + "' " +
                "," + bque.queue_id + "='" + p.queue_id.Replace("'", "''") + "' " +
                "Where " + bque.pkField + "='" + p.b_queue_date_id + "'"
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
        public String insertBQueue(BQueueDate p, String userId)
        {
            String re = "";
            if (p.b_queue_date_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }
            return re;
        }
        public DataTable selectAll(String date)
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*,concat(b_queue.queue_name,'[', b_queue.queue_prefix,']') as queue_name " +
                "From " + bque.table + " cop " +
                "inner join b_queue on b_queue.queue_id = cop.queue_id " +
                "Where  queue_date = '"+date+"' " +
                "Order By queue_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getlStf(String date)
        {
            //lDept = new List<Position>();

            lStf.Clear();
            DataTable dt = new DataTable();
            dt = selectAll(date);
            foreach (DataRow row in dt.Rows)
            {
                BQueueDate stf1 = new BQueueDate();
                stf1.b_queue_date_id = row[bque.b_queue_date_id].ToString();
                stf1.queue_id = row[bque.queue_id].ToString();
                stf1.queue_date = row[bque.queue_date].ToString();
                stf1.queue_current = row[bque.queue_current].ToString();
                stf1.queue = row[bque.queue].ToString();
                stf1.queuename = row["queue_name"].ToString();
                lStf.Add(stf1);
            }
        }
        public void setCboQueDate1(C1ComboBox c, String selected, String date)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            c.Items.Clear();
            int i = 0;
            if (lStf.Count <= 0) getlStf(date);
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (BQueueDate cus1 in lStf)
            {
                item = new ComboBoxItem();
                item.Value = cus1.b_queue_date_id;
                item.Text = cus1.queuename;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
        }
        public void setCboQueDate(ComboBox c, String selected, String date)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            c.Items.Clear();
            int i = 0;
            if (lStf.Count <= 0) getlStf(date);
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (BQueueDate cus1 in lStf)
            {
                item = new ComboBoxItem();
                item.Value = cus1.b_queue_date_id;
                item.Text = cus1.queuename;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
        }
        public String updateQueueMax(String bqueue_id)
        {
            String re = "", max="";
            String sql = "";
            int chk = 0;

            max = selectMaxQueByPk1(bqueue_id);
            sql = "Update " + bque.table + " Set " +
                //" " + bque.queue_date + "='" + p.queue_date + "' " +
                //"," + bque.queue_current + "='" + p.queue_current + "' " +
                " " + bque.queue_current + "='" + max + "' " +
                //"," + bque.staff_id + "='" + p.staff_id.Replace("'", "''") + "' " +
                "Where " + bque.pkField + "='" + bqueue_id + "'"
                ;

            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
                if (re.Equals("1"))
                {
                    re = max;
                }
                else
                {
                    re = "";
                }
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String QueuetNext(String bqueue_id, String quedate, String queue_date_id)
        {
            String re = "", sql = "";
            try
            {
                MySqlCommand cmd = new MySqlCommand("gen_queue_next", conn.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("?queue_id1", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("?queue_date1", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("?user_id1", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("?b_queue_date_id1", MySqlDbType.Int32));
                //cmd.Parameters.Add(new MySqlParameter("?ret", MySqlDbType.VarChar));
                cmd.Parameters["?queue_id1"].Direction = ParameterDirection.Input;
                cmd.Parameters["?queue_id1"].Value = bqueue_id;
                cmd.Parameters["?queue_date1"].Direction = ParameterDirection.Input;
                cmd.Parameters["?queue_date1"].Value = quedate;
                cmd.Parameters["?user_id1"].Direction = ParameterDirection.Input;
                cmd.Parameters["?user_id1"].Value = "";
                cmd.Parameters["?b_queue_date_id1"].Direction = ParameterDirection.Input;
                cmd.Parameters["?b_queue_date_id1"].Value = queue_date_id;
                //cmd.Parameters["?ret"].Direction = ParameterDirection.Output;
                conn.conn.Open();
                cmd.ExecuteNonQuery();
                //re = (string)cmd.Parameters["?ret"].Value;
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
        public String updateQueuetNext(String bqueue_id, String quedate)
        {
            String re = "", max = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + bque.table + " Set " +
                " " + bque.queue + "= " + bque.queue + "+1 " +
                "Where " + bque.b_queue_date_id + "='" + bqueue_id + "' and " + bque.queue_date + "='" + quedate + "'"
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
        public String updateQueueCurrentNext(String bqueue_id, String quedate)
        {
            String re = "", max = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + bque.table + " Set " +
                " " + bque.queue_current + "= "+ bque.queue_current + "+1 " +
                "Where " + bque.b_queue_date_id + "='" + bqueue_id + "' and " + bque.queue_date + "='" + quedate + "'"
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
        public String updateQueueCurrent(String bqueue_id, String quedate, String quecurr)
        {
            String re = "", max = "";
            String sql = "";
            int chk = 0;
            
            sql = "Update " + bque.table + " Set " +
                " " + bque.queue_current + "='" + quecurr + "' " +
                "Where " + bque.queue_id + "='" + bqueue_id + "' and "+bque.queue_date+"='"+ quedate + "'"
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
        public String deleteQueToday(String bqueue_id)
        {
            String re = "", max = "";
            String sql = "";
            int chk = 0;            
            sql = "Delete From " + bque.table + "  " +
                "Where " + bque.pkField + "='" + bqueue_id + "'"
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
        public String selectBQueIdByStfQueDate(String stfid, String date)
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "select bque.*, concat(stf.prefix, ' ', stf.staff_fname_t, ' ' , stf.staff_lname_t) as name   " +
                "From " + bque.table + " bque " +
                "LEft Join b_staff stf on bque.staff_Id = stf.staff_id " +
                " " +
                "Where  bque.queue_date = '" + date + "' and bque.staff_id = '"+stfid+"'";
            dt = conn.selectData(conn.conn, sql);
            if(dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["b_queue_id"].ToString()+"@"+ dt.Rows[0]["queue_current"].ToString();
            }
            return re;
        }
        public DataTable selectBQueDate(String date)
        {
            DataTable dt = new DataTable();
            String sql = "select bque.*, concat(stf.prefix, ' ', stf.staff_fname_t, ' ' , stf.staff_lname_t) as name   " +
                "From " + bque.table + " bque " +
                "LEft Join b_staff stf on bque.staff_Id = stf.staff_id " +
                " " +
                "Where  bque.queue_date = '"+ date + "' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectBQueDate1(String date)
        {
            DataTable dt = new DataTable();
            String sql = "select qued.*,que.queue_name,concat(que.queue_name,'[', que.queue_prefix,']') as queue_name1, '' as flag,que.queue_code,que.queue_prefix   " +
                "From " + bque.table + " qued " +
                "inner Join b_queue que on que.queue_id = qued.queue_id " +
                " " +
                "Where  qued.queue_date = '" + date + "' " +
                "Order By qued.queue_id";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public BQueueDate selectByPk1(String stfid)
        {
            BQueueDate stf1 = new BQueueDate();
            DataTable dt = new DataTable();
            String sql = "select qued.*, que.queue_name   " +
                "From " + bque.table + " qued " +
                "inner Join b_queue que on que.queue_id = qued.queue_id " +
                "Where  qued." + bque.b_queue_date_id + "='" + stfid + "'";
            dt = conn.selectData(conn.conn, sql);
            stf1 = setBQueue(dt);
            return stf1;
        }
        public BQueueDate selectByPk1(String date, String stfid)
        {
            BQueueDate stf1 = new BQueueDate();
            DataTable dt = new DataTable();
            String sql = "select qued.*, que.queue_name   " +
                "From " + bque.table + " qued " +
                "inner Join b_queue que on que.queue_id = qued.queue_id " +
                "Where  qued.queue_date = '" + date + "' and qued." + bque.queue_id + "='"+stfid+"'";
            dt = conn.selectData(conn.conn, sql);
            stf1 = setBQueue(dt);
            return stf1;
        }
        public String selectMaxQueByPk1(String bqueid)
        {
            String re = "0";
            int chk = 0;
            BQueueDate stf1 = new BQueueDate();
            DataTable dt = new DataTable();
            String sql = "select bque.*   " +
                "From " + bque.table + " bque " +
                "Where  bque."+bque.pkField+" = '" + bqueid + "'";
            dt = conn.selectData(conn.conn, sql);
            stf1 = setBQueue(dt);
            if(int.TryParse(stf1.queue_current, out chk))
            {
                chk++;
                re = chk.ToString();
            }
            return re;
        }
        public BQueueDate setBQueue(DataTable dt)
        {
            BQueueDate stf1 = new BQueueDate();
            if (dt.Rows.Count > 0)
            {
                stf1.b_queue_date_id = dt.Rows[0][bque.b_queue_date_id].ToString();
                stf1.queue_date = dt.Rows[0][bque.queue_date].ToString();
                stf1.queue_current = dt.Rows[0][bque.queue_current].ToString();
                stf1.queuename1 = dt.Rows[0]["queue_name"].ToString();
                stf1.queue_id = dt.Rows[0][bque.queue_id].ToString();
                stf1.queuename = dt.Rows[0]["queue_name"].ToString();
                stf1.queue = "";
            }
            else
            {
                setBQueue1(stf1);
            }
            return stf1;
        }
        private BQueueDate setBQueue1(BQueueDate stf1)
        {
            stf1.b_queue_date_id = "";
            stf1.queue_date = "";
            stf1.queue_current = "";
            stf1.queuename = "";
            stf1.queuename1 = "";
            stf1.queue_id = "";
            stf1.queue = "";
            return stf1;
        }
    }
}
