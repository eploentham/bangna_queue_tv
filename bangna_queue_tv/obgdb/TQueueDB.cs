using bangna_queue_tv.object1;
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
            tque.b_queue_id = "b_queue_id";
            tque.queue_date = "queue_date";
            tque.row_1 = "row_1";
            tque.queue_active = "queue_active";
            //que.row_1 = "row_1";
            tque.active = "active";
            tque.date_create = "date_creat";
            tque.date_modi = "date_modi";
            tque.date_cancel = "date_cancel";
            tque.user_create = "user_create";
            tque.user_modi = "user_modi";
            tque.user_cancel = "user_cancel";
            tque.status_queue = "status_queue";
            tque.queue_name = "queue_name";
            tque.date_begin = "date_begin";
            tque.date_finish = "date_finish";
            //que.queue = "queue";

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

            p.b_queue_id = long.TryParse(p.b_queue_id, out chk) ? chk.ToString() : "0";

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
                //"," + que.queue + "='" + p.queue.Replace("'", "''") + "' " +
                "," + tque.queue_date + "='" + p.queue_date.Replace("'", "''") + "' " +
                "," + tque.row_1 + "='" + p.row_1.Replace("'", "''") + "' " +
                "," + tque.queue_active + "='" + p.queue_active.Replace("'", "''") + "' " +
                "," + tque.status_queue + "='" + p.status_queue.Replace("'", "''") + "' " +
                "," + tque.queue_name + "='" + p.queue_name.Replace("'", "''") + "' " +
                "," + tque.date_begin + "='" + p.date_begin.Replace("'", "''") + "' " +
                "," + tque.date_finish + "='" + p.date_finish.Replace("'", "''") + "' " +
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

            if (p.b_queue_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public TQueue setQueue(DataTable dt)
        {
            TQueue stf1 = new TQueue();
            if (dt.Rows.Count > 0)
            {
                stf1.t_queue_id = dt.Rows[0][tque.t_queue_id].ToString();
                stf1.b_queue_id = dt.Rows[0][tque.b_queue_id].ToString();
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
                //stf1.date_finish = dt.Rows[0][que.date_finish].ToString();
                //stf1.queue = dt.Rows[0][que.queue].ToString();

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
            stf1.b_queue_id = "";
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
            return stf1;
        }
    }
}
