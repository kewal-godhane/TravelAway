using Infosys.TravelAwayDAL.Models;
using Infosys.TravelAwayDAL.TravelAwayRepository;
using Infosys.TravelAwayWebServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace Infosys.TravelAwayWebServices.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RegisterUserController:Controller
    {
        RegisterUserRepositiory rep;
       public RegisterUserController(RegisterUserRepositiory repo)
        {
            this.rep = repo;
        }

        [HttpPost]
        public int AddCustomer(CustomerModel custobj)
        {
            int role;
            try
            {
                role = rep.RegisterNewCustomer(custobj.EmailId, custobj.RoleId, custobj.FirstName, custobj.LastName, custobj.ContactNumber,
                    custobj.Address, custobj.DateOfBirth, custobj.Gender, custobj.UserPassword);
            }
            catch(Exception) 
            {
                role=-99;
            }
            return role;
        }
    }
}
