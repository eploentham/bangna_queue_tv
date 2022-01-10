using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bangna_queue_tv.object1
{
    public class TQueue:Persistent
    {
        public String t_queue_id { get; set; }
        public String queue_id { get; set; }
        public String queue_date { get; set; }
        public String row_1 { get; set; }
        public String queue_active { get; set; }
        public String status_queue { get; set; }
        public String queue_name { get; set; }
        public String date_begin { get; set; }
        public String date_finish { get; set; }
        public String queue { get; set; }
        public String queue_current { get; set; }
        public String b_queue_date_id { get; set; }
        public String queue_call_id { get; set; }
        public String prefix { get; set; }
        public String code { get; set; }
    }
}
