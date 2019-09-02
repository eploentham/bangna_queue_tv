using bangna_queue_tv.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace bangna_queue_tv.obgdb
{
    public class BQueueDB
    {
        public BQueue bque;
        ConnectDB conn;

        public BQueueDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            bque = new BQueue();
            bque.queue_id = "b_queue_id";
            bque.staff_id = "staff_id";
            bque.queue_date = "queue_date";
            bque.queue_current = "queue_current";
            bque.queue = "queue";

            bque.table = "b_queue";
            bque.pkField = "b_queue_id";
            
        }
        private void chkNull(BQueue p)
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

            p.staff_id = long.TryParse(p.staff_id, out chk) ? chk.ToString() : "0";
            
        }
        public String insert(BQueue p, String userId)
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
                "," + bque.staff_id + "='" + p.staff_id.Replace("'", "''") + "' " +
                
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
        public String update(BQueue p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + bque.table + " Set " +
                " " + bque.queue_date + "='" + p.queue_date + "' " +
                //"," + bque.queue_current + "='" + p.queue_current + "' " +
                "," + bque.queue + "='" + p.queue + "' " +
                "," + bque.staff_id + "='" + p.staff_id.Replace("'", "''") + "' " +
                "Where " + bque.pkField + "='" + p.queue_id + "'"
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
        public String insertBQueue(BQueue p, String userId)
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
        public String updateQueueMax(String bqueue_id)
        {
            String re = "", max="";
            String sql = "";
            int chk = 0;

            max = selectMaxQueByPk1(bqueue_id);
            sql = "Update " + bque.table + " Set " +
                //" " + bque.queue_date + "='" + p.queue_date + "' " +
                //"," + bque.queue_current + "='" + p.queue_current + "' " +
                " " + bque.queue + "='" + max + "' " +
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
                re = dt.Rows[0]["b_queue_id"].ToString();
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
        public BQueue selectByPk1(String date, String stfid)
        {
            BQueue stf1 = new BQueue();
            DataTable dt = new DataTable();
            String sql = "select bque.*, concat(stf.prefix, ' ', stf.staff_fname_t, ' ' , stf.staff_lname_t) as name   " +
                "From " + bque.table + " bque " +
                "LEft Join b_staff stf on bque.staff_Id = stf.staff_id " +
                "Where  bque.queue_date = '" + date + "' and bque."+bque.staff_id+"='"+stfid+"'";
            dt = conn.selectData(conn.conn, sql);
            stf1 = setBQueue(dt);
            return stf1;
        }
        public String selectMaxQueByPk1(String bqueid)
        {
            String re = "0";
            int chk = 0;
            BQueue stf1 = new BQueue();
            DataTable dt = new DataTable();
            String sql = "select bque.*   " +
                "From " + bque.table + " bque " +
                "Where  bque."+bque.pkField+" = '" + bqueid + "'";
            dt = conn.selectData(conn.conn, sql);
            stf1 = setBQueue(dt);
            if(int.TryParse(stf1.queue, out chk))
            {
                chk++;
                re = chk.ToString();
            }
            return re;
        }
        public BQueue setBQueue(DataTable dt)
        {
            BQueue stf1 = new BQueue();
            if (dt.Rows.Count > 0)
            {
                stf1.queue_id = dt.Rows[0][bque.queue_id].ToString();
                stf1.queue_date = dt.Rows[0][bque.queue_date].ToString();
                stf1.queue_current = dt.Rows[0][bque.queue_current].ToString();
                stf1.queue = dt.Rows[0][bque.queue].ToString();
                stf1.staff_id = dt.Rows[0][bque.staff_id].ToString();
                
            }
            else
            {
                setBQueue1(stf1);
            }
            return stf1;
        }
        private BQueue setBQueue1(BQueue stf1)
        {
            stf1.queue_id = "";
            stf1.queue_date = "";
            stf1.queue_current = "";
            stf1.queue = "";
            stf1.staff_id = "";
            return stf1;
        }
    }
}
