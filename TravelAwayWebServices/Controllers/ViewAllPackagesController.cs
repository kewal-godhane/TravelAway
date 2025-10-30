using Infosys.TravelAwayDAL.Models;
using Infosys.TravelAwayDAL.TravelAwayRepository;
using Infosys.TravelAwayWebServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infosys.TravelAwayWebServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ViewAllPackagesController : Controller
    {
        PackageRepository repo;
        LoginRepository loginRepository;
        public ViewAllPackagesController(PackageRepository rep, LoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
            repo = rep;
        }

        // API to get a list of all packages
        [HttpGet]
        public JsonResult GetPackages()
        {
            List<Package> packageList;
            try
            {
                packageList = repo.GetPackages();
            }

            catch (Exception e)

            {

                Console.WriteLine(e.Message);

                packageList = null;

            }

            return Json(packageList);

        }

        // API to get a list of all package categories

        [HttpGet]

        public JsonResult GetPackageCategories()

        {

            List<PackageCategory> packageCategoriesList;

            try

            {

                packageCategoriesList = repo.GetPackageCategories();

            }

            catch (Exception)

            {

                packageCategoriesList = null;

            }

            return Json(packageCategoriesList);

        }
    }
}
