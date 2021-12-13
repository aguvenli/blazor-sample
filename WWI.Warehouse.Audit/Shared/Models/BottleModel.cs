namespace WWI.Warehouse.Audit.Shared.Models
{
    public class BottleModel
    {
        public int BottleInstanceId { get; set; }
        public string? Title { get; set; } = "NA";
        public string? ImageUrl { get; set; } = "images/svg/bottle-placeholder.svg";
        public string? BottleryName { get; set; } = "NA";
        public string? DistilleryName { get; set; } = "NA";
        public int? DistilledYear { get; set; }
        public int? BottlingYear { get; set; }
        public int? Age { get; set; }
    }
}
