﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bangna_queue_tv.object1
{
    public class BQueue:Persistent
    {
        public String b_queue_id { get; set; }
        public String queue_code { get; set; }
        public String queue_name { get; set; }
        public String queue_start { get; set; }
        public String queue_date { get; set; }
        public String queue_prefix { get; set; }
        public String active { get; set; }
        public String status_queue { get; set; }
        public String staff_name { get; set; }
        public String date_begin { get; set; }
        public String date_finish { get; set; }
        public String queue { get; set; }
        public String status_everyday { get; set; }
    }
}
