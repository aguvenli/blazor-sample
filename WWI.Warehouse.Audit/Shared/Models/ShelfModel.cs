namespace WWI.Warehouse.Audit.Shared.Models
{
    public class ShelfModel
    {
        public int StorageShelfId { get; set; }
        public string Warehouse { get; set; }
        public string Aisle { get; set; }
        public string Rack { get; set; }
        public int Shelf { get; set; }
        public ShelfNavigationModel Navigation { get; set; }
        public IEnumerable<StorageLocationModel> Locations { get; set; } = new List<StorageLocationModel>();

        public IEnumerable<string> Columns => Locations.Select(x => x.Column).Distinct().OrderBy(x => x);
        public IEnumerable<int> Rows => Locations.Select(x=>x.Row).Distinct().OrderByDescending(x => x);

        public StorageLocationModel GetLocation(string? column, int row)
        {
            return Locations.Single(x => x.Column == column && x.Row == row);
        }
    }

}
