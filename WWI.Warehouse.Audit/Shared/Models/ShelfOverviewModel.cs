using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWI.Warehouse.Audit.Shared.Models
{
    public class ShelfOverviewModel
    {
        public ShelfOverviewModel()
        {

        }

        public ShelfOverviewModel(List<ShelfModel> shelfModels, int totalItemCount)
        {
            ShelfModels = shelfModels;
            TotalItemCount = totalItemCount;
        }

        public List<ShelfModel> ShelfModels { get; set; } = new List<ShelfModel>();
        public int TotalItemCount { get; set; }
    }
}
