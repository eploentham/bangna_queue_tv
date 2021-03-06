﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bangna_queue_tv.obgdb
{
    public class BangnaQueueDB
    {
        ConnectDB conn;

        public BQueueDB bqueDB;
        public QueueDB queDB;
        public StaffDB stfDB;

        public BangnaQueueDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            stfDB = new StaffDB(conn);
            bqueDB = new BQueueDB(conn);
            queDB = new QueueDB(conn);
        }
    }
}
