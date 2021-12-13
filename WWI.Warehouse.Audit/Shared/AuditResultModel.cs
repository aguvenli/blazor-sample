using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWI.Warehouse.Audit.Shared
{
    public class AuditResultModel
    {
        [Range(1, int.MaxValue)]
        public int StorageLocationId { get; set; }
        public DateTime AuditedOn { get; set; }
        public string? Note { get; set; }
    }
}
