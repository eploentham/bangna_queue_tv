using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bangna_queue_tv.object1
{
    public class BQueueCaller:Persistent
    {
        public String queue_call_id { get; set; }
        public String queue_call_name { get; set; }
        public String status_lock { get; set; }
    }
}
