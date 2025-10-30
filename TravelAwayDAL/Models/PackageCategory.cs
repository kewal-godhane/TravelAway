using System;
using System.Collections.Generic;

namespace Infosys.TravelAwayDAL.Models
{
    public partial class PackageCategory
    {
        public PackageCategory()
        {
            Packages = new HashSet<Package>();
        }

        public int PackageCategoryId { get; set; }
        public string PackageCategoryName { get; set; } = null!;

        public virtual ICollection<Package> Packages { get; set; }
    }
}
