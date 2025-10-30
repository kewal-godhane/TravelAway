using Infosys.TravelAwayDAL.Models;
using Infosys.TravelAwayDAL.TravelAwayRepository;
using Infosys.TravelAwayWebServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Infosys.TravelAwayWebServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : Controller
    {
        LoginRepository loginRepository;

        public LoginController(LoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        [HttpPost]
        public JsonResult ValidateLoginDetails(Login login)
        {
            Customer customer = new Customer();
            try
            {
                customer = this.loginRepository.ValidateLoginCustomer(login.EmailId, login.UserPassword);
            }
            catch (Exception)
            {
                customer.RoleId = 0;
            }
            return Json(customer);
        }
    }
}
