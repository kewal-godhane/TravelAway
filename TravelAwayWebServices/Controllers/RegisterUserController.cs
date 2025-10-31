using Infosys.TravelAwayDAL.Models;
using Infosys.TravelAwayDAL.TravelAwayRepository;
using Infosys.TravelAwayWebServices.Models;
using Infosys.TravelAwayWebServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace Infosys.TravelAwayWebServices.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RegisterUserController:Controller
    {
        RegisterUserRepositiory rep;
        private readonly TokenService _tokenService;
        public RegisterUserController(RegisterUserRepositiory repo, TokenService tokenService)
        {
            this.rep = repo;
            _tokenService = tokenService;

        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerModel custobj)
        {
            int role;
            try
            {
                role = rep.RegisterNewCustomer(custobj.EmailId, custobj.RoleId, custobj.FirstName,
                    custobj.LastName,
                    custobj.ContactNumber,
                    custobj.Address, custobj.DateOfBirth, custobj.Gender, custobj.UserPassword);
            }
            catch(Exception) 
            {
                return StatusCode(500, "An error occurred during registertion."); ;
            }
            Customer customer = new Customer();
            customer.RoleId = custobj.RoleId;
            customer.EmailId = custobj.EmailId;
            var token = _tokenService.CreateToken(customer);
            //if()
            return Json(new
            {
                token,
                user = new
                {
                    customer.EmailId,
                    customer.RoleId
                }
            }); 
        }
    }
}
