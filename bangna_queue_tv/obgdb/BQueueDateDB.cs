using bangna_queue_tv.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace bangna_queue_tv.obgdb
{
    public class BQueueDateDB
    {
        public BQueueDate bque;
        ConnectDB conn;

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
            bque.queue_current = "queue_current";
            //bque.queue = "queue";

            bque.table = "b_queue_date";
            bque.pkField = "b_queue_date_id";
            
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
            //p.queue = p.queue == null ? "" : p.queue;

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
                //"," + bque.queue + "='" + p.queue + "' " +
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
            String sql = "select qued.*, que.queue_name, '' as flag   " +
                "From " + bque.table + " qued " +
                "inner Join b_queue que on que.queue_id = qued.queue_id " +
                " " +
                "Where  qued.queue_date = '" + date + "' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public BQueueDate selectByPk1(String date, String stfid)
        {
            BQueueDate stf1 = new BQueueDate();
            DataTable dt = new DataTable();
            String sql = "select bque.*, concat(stf.prefix, ' ', stf.staff_fname_t, ' ' , stf.staff_lname_t) as name   " +
                "From " + bque.table + " bque " +
                "LEft Join b_staff stf on bque.staff_Id = stf.staff_id " +
                "Where  bque.queue_date = '" + date + "' and bque."+bque.queue_id + "='"+stfid+"'";
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
                //stf1.queue = dt.Rows[0][bque.queue].ToString();
                stf1.queue_id = dt.Rows[0][bque.queue_id].ToString();
                
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
            //stf1.queue = "";
            stf1.queue_id = "";
            return stf1;
        }
    }
}
