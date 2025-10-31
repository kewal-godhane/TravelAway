using Infosys.TravelAwayDAL.Models;
using Infosys.TravelAwayDAL.TravelAwayRepository;
using Infosys.TravelAwayWebServices.Models;
using Infosys.TravelAwayWebServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Infosys.TravelAwayWebServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : Controller
    {
        LoginRepository loginRepository;
        private readonly TokenService _tokenService;

        public LoginController(LoginRepository loginRepository, TokenService tokenService)
        {
            this.loginRepository = loginRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult ValidateLoginDetails(Login login)
        {
            Customer customer;
            //Customer customer = new Customer();
            try
            {
                customer = this.loginRepository.ValidateLoginCustomer(login.EmailId, login.UserPassword);
            }
            catch (Exception)
            {
                //customer.RoleId = 0;
                return StatusCode(500, "An error occurred during login.");
            }
            if (customer == null || customer.RoleId == 0)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            var token = _tokenService.CreateToken(customer);

            // Return token and minimal user data
            return Json(new
            {
                token,
                user = new
                {
                    customer.EmailId,
                    customer.RoleId,
                    customer.FirstName,
                    customer.LastName
                }
            });
            //return Json(customer);
        }
    }
}
