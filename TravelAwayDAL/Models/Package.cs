using System;
using System.Collections.Generic;

namespace Infosys.TravelAwayDAL.Models
{
    public partial class Package
    {
        public Package()
        {
            PackageDetails = new HashSet<PackageDetail>();
        }

        public int PackageId { get; set; }
        public string PackageName { get; set; } = null!;
        public int? PackageCategoryId { get; set; }
        public string? TypeOfPackage { get; set; }
        public string? ImageUrl { get; set; }

        public virtual PackageCategory? PackageCategory { get; set; }
        public virtual ICollection<PackageDetail> PackageDetails { get; set; }
    }
}
