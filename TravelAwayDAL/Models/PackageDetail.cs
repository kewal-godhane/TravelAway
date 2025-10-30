using System;
using System.Collections.Generic;

namespace Infosys.TravelAwayDAL.Models
{
    public partial class PackageDetail
    {
        public PackageDetail()
        {
            BookPackages = new HashSet<BookPackage>();
        }

        public int PackageDetailsId { get; set; }
        public int? PackageId { get; set; }
        public string PlacesToVisit { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int NoOfDays { get; set; }
        public int NoOfNights { get; set; }
        public string? Accomodation { get; set; }
        public decimal? PricePerAdult { get; set; }

        public virtual Package? Package { get; set; }
        public virtual ICollection<BookPackage> BookPackages { get; set; }
    }
}
