using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infosys.TravelAwayDAL.Models;

namespace Infosys.TravelAwayDAL.TravelAwayRepository
{
    
        public class LoginRepository
        {
            public TravelAwayDBContext Context { get; set; }


            public LoginRepository(TravelAwayDBContext context )
            {
                this.Context = context;
            }


        // Method to validate a User
        public Customer ValidateLoginCustomer(string emailId, string password)
        {
            var customer = new Customer();
            try
            {
                customer = (from usr in Context.Customers
                            where usr.EmailId == emailId
                            select usr).FirstOrDefault();
                if (customer != null)
                {
                    customer = (from usr in Context.Customers
                                where usr.EmailId == emailId && usr.UserPassword == password
                                select usr).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                customer.RoleId = 0;
            }
            return customer;
        }
    }
}
