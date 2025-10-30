namespace Infosys.TravelAwayWebServices.Models
{
    public class PackageDetails
    {
        public int PackageDetailsId { get; set; }
        public int? PackageId { get; set; }
        public string PlacesToVisit { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int NoOfDays { get; set; }
        public int NoOfNights { get; set; }
        public string? Accomodation { get; set; }
        public decimal? PricePerAdult { get; set; }
    }
}
