using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWI.Warehouse.Audit.Shared.Models
{
    public class ShelfNavigationModel
    {
        public int? NextShelfId { get; set; }
        public int? PreviousShelfId { get; set; }
        public int? NextRackShelfId { get; set; }
        public int? PreviousRackShelfId { get; set; }

    }
}
