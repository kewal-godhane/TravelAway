using System;
using System.Collections.Generic;

namespace Infosys.TravelAwayDAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            BookPackages = new HashSet<BookPackage>();
        }

        public string EmailId { get; set; } = null!;
        public byte? RoleId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public decimal ContactNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = null!;

        public virtual Role? Role { get; set; }
        public virtual ICollection<BookPackage> BookPackages { get; set; }
    }
}
