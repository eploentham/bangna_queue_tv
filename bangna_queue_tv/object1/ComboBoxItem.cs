using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bangna_queue_tv
{
    public class ComboBoxItem
    {
        public String Text { get; set; }
        public String Value { get; set; }

        public override String ToString()
        {
            return Text;
        }
    }
}
