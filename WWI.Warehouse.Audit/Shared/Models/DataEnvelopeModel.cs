using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWI.Warehouse.Audit.Shared.Models
{
    public class DataEnvelopeModel
    {
        public List<ShelfModel> GridData { get; set; }
        public int TotalItemCount { get; set; }
    }
}
