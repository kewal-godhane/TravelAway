using System;
using System.Collections.Generic;

namespace Infosys.TravelAwayDAL.Models
{
    public partial class Role
    {
        public Role()
        {
            Customers = new HashSet<Customer>();
        }

        public byte RoleId { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
