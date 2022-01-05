using bangna_queue_tv.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bangna_queue_tv.obgdb
{
    public class TCallDB
    {
        public TCall tcall;
        ConnectDB conn;

        public TCallDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            tcall = new TCall();
            tcall.call_id = "call_id";
            tcall.queue_id = "queue_id";
            tcall.queue = "queue";
            tcall.prefix = "prefix";
            tcall.code = "code";
            tcall.status_call = "status_call";

            tcall.date_create = "date_create";
            tcall.date_modi = "date_modi";
            tcall.date_cancel = "date_cancel";
            tcall.user_create = "user_create";
            tcall.user_modi = "user_modi";
            tcall.user_cancel = "user_cancel";

            tcall.table = "t_call";
            tcall.pkField = "call_id";
        }
        private void chkNull(TCall p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            
            p.prefix = p.prefix == null ? "" : p.prefix;
            p.code = p.code == null ? "" : p.code;
            p.status_call = p.status_call == null ? "" : p.status_call;

            p.queue_id = long.TryParse(p.queue_id, out chk) ? chk.ToString() : "0";            
            p.queue = long.TryParse(p.queue, out chk) ? chk.ToString() : "0";
        }
        public String insert(TCall p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);

            sql = "Insert Into " + tcall.table + " set " +                
                " " + tcall.active + "='1' " +
                "," + tcall.date_create + "= now() " +
                "," + tcall.user_create + "='" + userId.Replace("'", "''") + "' " +
                "," + tcall.prefix + "='" + p.prefix.Replace("'", "''") + "' " +
                "," + tcall.code + "='" + p.code.Replace("'", "''") + "' " +
                "," + tcall.status_call + "='0' " +
                "," + tcall.queue_id + "='" + p.queue_id.Replace("'", "''") + "' " +
                "," + tcall.queue + "='" + p.queue.Replace("'", "''") + "' " +
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
        public String deleteCallById(String call_id, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Delete From " + tcall.table + "  " +
                "Where " + tcall.pkField + "='" + call_id + "'"
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
    }
}
