using bangna_queue_tv.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace bangna_queue_tv.obgdb
{
    public class QueueDB
    {
        public Queue que;
        ConnectDB conn;

        public QueueDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            que = new Queue();
            que.queue_id = "queue_id";
            que.staff_id = "staff_id";
            que.queue_date = "queue_date";
            que.row_1 = "row_1";
            que.active = "active";
            que.status_queue = "status_queue";
            que.staff_name = "staff_name";
            que.date_begin = "date_begin";
            que.date_finish = "date_finish";
            que.queue = "queue";

            que.table = "t_queue";
            que.pkField = "queue_id";

        }
        private void chkNull(Queue p)
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
            p.row_1 = p.row_1 == null ? "" : p.row_1;
            p.active = p.active == null ? "" : p.active;
            p.status_queue = p.status_queue == null ? "" : p.status_queue;
            p.staff_name = p.staff_name == null ? "" : p.staff_name;
            p.date_begin = p.date_begin == null ? "" : p.date_begin;
            p.date_finish = p.date_finish == null ? "" : p.date_finish;
            p.queue = p.queue == null ? "" : p.queue;

            p.staff_id = long.TryParse(p.staff_id, out chk) ? chk.ToString() : "0";

        }
        public String insert(Queue p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);

            sql = "Insert Into " + que.table + " set " +
                " " + que.queue_date + "= now() " +
                "," + que.row_1 + "='" + p.row_1 + "' " +
                "," + que.active + "='1' " +
                "," + que.staff_id + "='" + p.staff_id.Replace("'", "''") + "' " +
                "," + que.status_queue + "='1' " +
                "," + que.staff_name + "='" + p.staff_name.Replace("'", "''") + "' " +
                "," + que.date_begin + "= now() " +
                "," + que.date_finish + "='" + p.date_finish.Replace("'", "''") + "' " +
                "," + que.queue + "='" + p.queue.Replace("'", "''") + "' " +
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
        public String update(Queue p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + que.table + " Set " +
                " " + que.queue_date + "='" + p.queue_date + "' " +
                "," + que.row_1 + "='" + p.row_1 + "' " +
                "," + que.active + "='" + p.active + "' " +
                "," + que.staff_id + "='" + p.staff_id.Replace("'", "''") + "' " +
                "," + que.status_queue + "='" + p.status_queue.Replace("'", "''") + "' " +
                "," + que.staff_name + "='" + p.staff_name.Replace("'", "''") + "' " +
                "," + que.date_begin + "='" + p.date_begin.Replace("'", "''") + "' " +
                "," + que.date_finish + "='" + p.date_finish.Replace("'", "''") + "' " +
                "Where " + que.pkField + "='" + p.staff_id + "'"
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
        public Queue updateStatusQue(String stfid, String date)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            Queue stf1 = new Queue();
            Queue stf2 = new Queue();
            stf1 = selectQueByStfQueDate(stfid, date);
            sql = "Update " + que.table + " Set " +
                //" " + que.queue_date + "='" + p.queue_date + "' " +
                //"," + que.row_1 + "='" + p.row_1 + "' " +
                //"," + que.active + "='" + p.active + "' " +
                //"," + que.staff_id + "='" + p.staff_id.Replace("'", "''") + "' " +
                " " + que.status_queue + "='2' " +
                //"," + que.staff_name + "='" + p.staff_name.Replace("'", "''") + "' " +
                //"," + que.date_begin + "='" + p.date_begin.Replace("'", "''") + "' " +
                "," + que.date_finish + "= now() " +
                "Where " + que.pkField + "='" + stf1.queue_id + "'"
                ;

            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
                if(int.TryParse(re, out chk))
                {
                    stf2 = selectQueByStfQueDate(stfid, date);

                }
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return stf2;
        }
        public String updateQue(String queid, String que1)
        {
            String re = "";
            String sql = "";
            int chk = 0;            
            sql = "Update " + que.table + " Set " +
                " " + que.queue + "='"+ que1 + "' " +
                "Where " + que.pkField + "='" + queid + "'"
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
        public String insertQueue(Queue p, String userId)
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
        public Queue selectQueByStfQueDate(String stfid, String date)
        {
            Queue stf1 = new Queue();
            String re = "";
            DataTable dt = new DataTable();
            String sql = "select que.*   " +
                "From " + que.table + " que " +
                " " +
                "Where  que.queue_date >= '" + date + " 00:00:00' and que.queue_date <= '"+date+" 23:59:59' and que.staff_id = '" + stfid + "' and que."+que.status_queue+"='1' " +
                "Order By que."+que.queue_id+" asc";
            dt = conn.selectData(conn.conn, sql);
            stf1 = setQueue(dt);
            return stf1;
        }
        public Queue setQueue(DataTable dt)
        {
            Queue stf1 = new Queue();
            if (dt.Rows.Count > 0)
            {
                stf1.queue_id = dt.Rows[0][que.queue_id].ToString();
                stf1.staff_id = dt.Rows[0][que.staff_id].ToString();
                stf1.queue_date = dt.Rows[0][que.queue_date].ToString();
                stf1.row_1 = dt.Rows[0][que.row_1].ToString();
                stf1.active = dt.Rows[0][que.active].ToString();
                stf1.status_queue = dt.Rows[0][que.status_queue].ToString();
                stf1.staff_name = dt.Rows[0][que.staff_name].ToString();
                stf1.date_begin = dt.Rows[0][que.date_begin].ToString();
                stf1.date_finish = dt.Rows[0][que.date_finish].ToString();
                stf1.queue = dt.Rows[0][que.queue].ToString();

            }
            else
            {
                setQueue1(stf1);
            }
            return stf1;
        }
        private Queue setQueue1(Queue stf1)
        {
            stf1.queue_id = "";
            stf1.staff_id = "";
            stf1.queue_date = "";
            stf1.row_1 = "";
            stf1.active = "";
            stf1.status_queue = "";
            stf1.staff_name = "";
            stf1.date_begin = "";
            stf1.date_finish = "";
            stf1.queue = "";
            return stf1;
        }
    }
}
