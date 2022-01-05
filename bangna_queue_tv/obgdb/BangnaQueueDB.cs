using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bangna_queue_tv.obgdb
{
    public class BangnaQueueDB
    {
        ConnectDB conn;

        public BQueueDateDB queDateDB;
        public BQueueDB queDB;
        public StaffDB stfDB;
        public TQueueDB tqueDB;
        public BQueueCallerDB quecDB;
        public TCallDB tcallDB;
        public BangnaQueueDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            stfDB = new StaffDB(conn);
            queDateDB = new BQueueDateDB(conn);
            queDB = new BQueueDB(conn);
            tqueDB = new TQueueDB(conn);
            quecDB = new BQueueCallerDB(conn);
            tcallDB = new TCallDB(conn);

            queDB.getlStf();
        }
    }
}
