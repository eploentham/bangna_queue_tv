using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bangna_queue_tv.object1
{
    public class BQueueDate:Persistent
    {
        public String b_queue_date_id { get; set; }
        public String queue_id { get; set; }
        public String queue_date { get; set; }
        public String queue_current { get; set; }//ตอนนี้ ถึงคิว ที่เท่าไร จะได้รู้ว่าต้องรอ อีกกี่คิว
        public String queue { get; set; }//คิวที่กดได้ เลขที่คิว
        public String queuename { get; set; }
        public String queuename1 { get; set; }
    }
}
