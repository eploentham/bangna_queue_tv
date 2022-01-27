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
        public CompanyDB compDB;
        public BangnaQueueDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            try
            {
                //new LogWriter("d", "BangnaQueueDB initConfig ");
                stfDB = new StaffDB(conn);
                queDateDB = new BQueueDateDB(conn);
                queDB = new BQueueDB(conn);
                tqueDB = new TQueueDB(conn);
                quecDB = new BQueueCallerDB(conn);
                tcallDB = new TCallDB(conn);
                compDB = new CompanyDB(conn);

                queDB.getlStf();
            }
            catch(Exception ex)
            {
                new LogWriter("e", "BangnaQueueDB initConfig "+ex.Message);
            }
        }
    }
}
