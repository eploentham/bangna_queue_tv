using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bangna_queue_tv.object1
{
    public class TCall:Persistent
    {
        public String call_id { get; set; }
        public String queue_id { get; set; }
        public String queue { get; set; }
        public String prefix { get; set; }
        public String code { get; set; }
        public String status_call { get; set; }
    }
}
