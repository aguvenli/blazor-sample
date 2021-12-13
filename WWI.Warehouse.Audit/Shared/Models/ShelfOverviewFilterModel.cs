using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWI.Warehouse.Audit.Shared.Models
{
    public class ShelfOverviewFilterModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string? Warehouse { get; set; }
        public string? Aisle { get; set; }
        public string? Rack { get; set; }
        public string? Shelf { get; set; }

        public ShelfOverviewFilterModel()
        {
            this.PageIndex = 0;
            this.PageSize = 10;
            Warehouse = "";
            Aisle = "";
            Rack = "";
            Shelf = "";
        }
        public ShelfOverviewFilterModel(int pageNumber, int pageSize, string? warehouse, string? aisle, string? rack, string? shelf)
        {
            this.PageIndex = pageNumber < 0 ? 0 : pageNumber;
            this.PageSize = pageSize < 10 ? 10 : pageSize;
            Warehouse = warehouse;
            Aisle = aisle;
            Rack = rack;
            Shelf = shelf;
        }

    }
}
