﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bangna_queue_tv.object1
{
    public class BQueue:Persistent
    {
        public String queue_id { get; set; }
        public String staff_id { get; set; }
        public String queue_date { get; set; }
        public String queue_current { get; set; }
        public String queue { get; set; }
    }
}
