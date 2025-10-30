using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infosys.TravelAwayDAL.Models
{
    public partial class BookPackage
    {
        public BookPackage()
        {
            Accomodations = new HashSet<Accomodation>();
        }

        public string? EmailId { get; set; }
        public int BookingId { get; set; }
        public decimal ContactNumber { get; set; }
        public string Address { get; set; } = null!;
        public DateTime DateOfTravel { get; set; }
        public int NumberOfAdults { get; set; }
        public int? NumberOfChildren { get; set; }
        public string Status { get; set; } = null!;
        public int? PackageId { get; set; }

        [JsonIgnore]
        public virtual Customer? Email { get; set; }
        [JsonIgnore]
        public virtual PackageDetail? Package { get; set; }
        [JsonIgnore]
        public virtual ICollection<Accomodation> Accomodations { get; set; }
    }
}
