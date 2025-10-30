using Infosys.TravelAwayDAL.TravelAwayRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infosys.TravelAwayWebServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportsController : Controller
    {
        ReportsRepository repo;
        LoginRepository loginRepository;
        public ReportsController(ReportsRepository rep, LoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
            repo = rep;
        }
        [HttpGet]
        public JsonResult GetPackageCountByCateory()
        {
            List<Object> PackageCountByCateory;
            try
            {
                PackageCountByCateory = repo.packageCountByCateory();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                PackageCountByCateory = null;
            }
            return Json(PackageCountByCateory);
        }

        [HttpGet]
        public JsonResult GetBookingCountByPackage()
        {
            List<object> BookingCountByPackage;
            try
            {
                BookingCountByPackage = repo.BookingCountByPackage();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                BookingCountByPackage = null;
            }
            return Json(BookingCountByPackage);
        }
    }
}
