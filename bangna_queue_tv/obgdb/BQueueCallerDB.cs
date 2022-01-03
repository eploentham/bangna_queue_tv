using bangna_queue_tv.object1;
using C1.Win.C1Ribbon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bangna_queue_tv.obgdb
{
    public class BQueueCallerDB
    {
        public BQueueCaller quec;
        ConnectDB conn;
        public List<BQueueCaller> lStf;
        public BQueueCallerDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            quec = new BQueueCaller();
            quec.queue_call_id = "queue_call_id";
            quec.queue_call_name = "queue_call_name";

            quec.active = "active";
            quec.date_create = "date_create";
            quec.date_modi = "date_modi";
            quec.date_cancel = "date_cancel";
            quec.user_create = "user_create";
            quec.user_modi = "user_modi";
            quec.user_cancel = "user_cancel";

            quec.status_lock = "status_lock";

            quec.table = "b_queue_call";
            quec.pkField = "queue_call_id";
            lStf = new List<BQueueCaller>();
        }
        private void chkNull(BQueueCaller p)
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
            p.queue_call_name = p.queue_call_name == null ? "" : p.queue_call_name;
            p.status_lock = p.status_lock == null ? "" : p.status_lock;
        }
        public String insert(BQueueCaller p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);

            sql = "Insert Into " + quec.table + " set " +
                " " + quec.active + "='1' " +
                "," + quec.queue_call_name + "='" + p.queue_call_name.Replace("'", "''") + "' " +
                "," + quec.date_create + "= now() " +
                "," + quec.user_create + "='" + userId.Replace("'", "''") + "' " +
                "," + quec.status_lock + "='" + p.status_lock.Replace("'", "''") + "' " +
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
        public String update(BQueueCaller p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + quec.table + " Set " +
                " " + quec.date_modi + "=now() " +
                "," + quec.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + quec.queue_call_name + "='" + p.queue_call_name.Replace("'", "''") + "' " +
                "Where " + quec.pkField + "='" + p.queue_call_id + "'"
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
        public String updateStatusLock(String callerid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            
            sql = "Update " + quec.table + " Set " +
                " " + quec.status_lock + "='1' " +                
                "Where " + quec.pkField + "='" + callerid + "'"
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
        public String updateStatusUnLock(String callerid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            
            sql = "Update " + quec.table + " Set " +
                " " + quec.status_lock + "='0' " +
                "Where " + quec.pkField + "='" + callerid + "'"
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
        public String insertQueueCaller(BQueueCaller p, String userId)
        {
            String re = "";

            if (p.queue_call_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String voiQueueCaller(String queuecallerid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + quec.table + " Set " +
                " " + quec.date_cancel + "=now() " +
                "," + quec.user_cancel + "='" + userId.Replace("'", "''") + "' " +
                "," + quec.active + "='3' " +
                "Where " + quec.pkField + "='" + queuecallerid + "'"
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
        public DataTable selectAll()
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "select que.*   " +
                "From " + quec.table + " que " +
                " " +
                "Where  que.active = '1' " +
                "Order By que." + quec.queue_call_id + " asc";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public BQueueCaller selectByPk(String queid)
        {
            BQueueCaller stf1 = new BQueueCaller();
            String re = "";
            DataTable dt = new DataTable();
            String sql = "select que.*   " +
                "From " + quec.table + " que " +
                " " +
                "Where  que.queue_id = '" + queid + "' " +
                "Order By que." + quec.queue_call_id + " asc";
            dt = conn.selectData(conn.conn, sql);
            stf1 = setQueueCaller(dt);
            return stf1;
        }
        public BQueueCaller selectByName(String name)
        {
            BQueueCaller stf1 = new BQueueCaller();
            String re = "";
            DataTable dt = new DataTable();
            String sql = "select que.*   " +
                "From " + quec.table + " que " +
                " " +
                "Where  que.queue_call_name = '" + name + "' and que.active = '1' " +
                "Order By que." + quec.queue_call_id + " asc";
            dt = conn.selectData(conn.conn, sql);
            stf1 = setQueueCaller(dt);
            return stf1;
        }
        public void getlStf()
        {
            //lDept = new List<Position>();

            lStf.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                BQueueCaller stf1 = new BQueueCaller();
                stf1.queue_call_id = row[quec.queue_call_id].ToString();
                stf1.queue_call_name = row[quec.queue_call_name].ToString();                
                lStf.Add(stf1);
            }
        }
        public void setCboQueDate(RibbonComboBox c, String selected)
        {            
            c.Items.Clear();
            int i = 0;
            if (lStf.Count <= 0) getlStf();
            c.Items.Add("");
            foreach (BQueueCaller cus1 in lStf)
            {
                c.Items.Add(cus1.queue_call_name);
            }
        }
        public BQueueCaller setQueueCaller(DataTable dt)
        {
            BQueueCaller stf1 = new BQueueCaller();
            if (dt.Rows.Count > 0)
            {
                stf1.queue_call_id = dt.Rows[0][quec.queue_call_id].ToString();
                stf1.queue_call_name = dt.Rows[0][quec.queue_call_name].ToString();
                
                stf1.date_create = dt.Rows[0][quec.date_create].ToString();
                stf1.date_modi = dt.Rows[0][quec.date_modi].ToString();
                stf1.date_cancel = dt.Rows[0][quec.date_cancel].ToString();
                stf1.user_create = dt.Rows[0][quec.user_create].ToString();
                stf1.user_modi = dt.Rows[0][quec.user_modi].ToString();
                stf1.user_cancel = dt.Rows[0][quec.user_cancel].ToString();

                stf1.status_lock = dt.Rows[0][quec.status_lock].ToString();

                stf1.active = dt.Rows[0][quec.active].ToString();
                
            }
            else
            {
                setQueueCaller(stf1);
            }
            return stf1;
        }
        private BQueueCaller setQueueCaller(BQueueCaller stf1)
        {
            stf1.queue_call_id = "";
            stf1.queue_call_name = "";
            
            stf1.date_create = "";
            stf1.active = "";
            stf1.date_modi = "";
            stf1.date_cancel = "";
            stf1.user_create = "";
            stf1.user_modi = "";
            stf1.user_cancel = "";
            stf1.status_lock = "";

            return stf1;
        }
    }
}
