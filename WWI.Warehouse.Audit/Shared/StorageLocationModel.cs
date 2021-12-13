using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWI.Warehouse.Audit.Shared.Models;

namespace WWI.Warehouse.Audit.Shared
{
    public class StorageLocationModel
    {
        public int StorageLocationId { get; set; }

        public string Column { get; set; }
        public int Row { get; set; }

        public bool IsOccupied => Occupant != null;
        public BottleModel Occupant { get; set; }


        public DateTime? LastCheckedOn { get; set; }
        public bool? LastCheckWasOk { get; set; }


        public string Title => IsOccupied ? Occupant.Title : "Empty Location";



    }
}
