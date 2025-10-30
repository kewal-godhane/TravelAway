using Infosys.TravelAwayDAL.Models;
using Infosys.TravelAwayDAL.TravelAwayRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infosys.TravelAwayWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageDetailsController : Controller
    {

        PackageDetailsRepository packageDetailsRepository;

        public PackageDetailsController(PackageDetailsRepository packageDetailsRepository)
        {
            this.packageDetailsRepository = packageDetailsRepository;
        }

        [HttpGet]
        public JsonResult GetPackageDetails(int id) 
        {
            var packageDetail = new List<PackageDetail>();    
            try
            {
                packageDetail = this.packageDetailsRepository.GetPackageDetails(id);
                if (packageDetail == null) {
                    Console.WriteLine("No package details found");
                    packageDetail = null;
                }
                else
                {
                    Console.WriteLine("Package Details fetched successfully");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Some error occured in Package Details");
            }
            return Json(packageDetail);
        }

    }
}
