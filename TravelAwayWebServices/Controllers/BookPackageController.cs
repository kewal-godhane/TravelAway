using Infosys.TravelAwayDAL.Models;
using Infosys.TravelAwayDAL.TravelAwayRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infosys.TravelAwayWebServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookPackageController : Controller
    {
        BookPackageRepository repository;

        public BookPackageController(BookPackageRepository bookPackageRepository)
        {
            this.repository = bookPackageRepository;
        }

        [HttpPost]
        public int BookPackage(BookPackage bookPackage)
        {
            int bookingId = 0;
            try
            {
                bookingId = this.repository.BookPackage(bookPackage);
                if (bookingId < 0)
                {
                    Console.WriteLine("Some error occured");
                }
            }
            catch (Exception)
            {
                bookingId = -99;
            }
            return bookingId;
        }

        [HttpGet]
        public List<BookPackage> GetBookPackages(string emailId) 
        {
            List<BookPackage> bookPackages = new List<BookPackage>();   
            try
            {
                bookPackages = this.repository.GetBookPackages(emailId);
                if (bookPackages == null) 
                {
                    Console.WriteLine("bookPackages is empty");
                }
            }
            catch (Exception)
            {
                bookPackages = null;
                Console.WriteLine("Error occured in getbookpackages");
            }
            return bookPackages;
        }


    }
}
