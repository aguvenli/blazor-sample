using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWI.Warehouse.Audit.Shared
{
    public class AuditLocationModel
    {
        public int LocationId { get; set; }
        public DateTime AuditedOn { get; set; }
        public string Note { get; set; }
    }

    

    

}
