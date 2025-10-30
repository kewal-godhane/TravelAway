using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infosys.TravelAwayDAL.Models;

namespace Infosys.TravelAwayDAL.TravelAwayRepository
{
    public class BookPackageRepository
    {
        private TravelAwayDBContext dbContext;

        public BookPackageRepository(TravelAwayDBContext travelAwayDBContext)
        {
            this.dbContext = travelAwayDBContext;
        }

        public int BookPackage(BookPackage bookPackage)
        {
            int bookId = 0;
            try
            {
                this.dbContext.BookPackages.Add(bookPackage);
                this.dbContext.SaveChanges();
                bookId = bookPackage.BookingId;
            }
            catch (Exception)
            {
                bookId = -99;
            }
            return bookId;
        }

        public List<BookPackage> GetBookPackages(string emailId)
        {
            List<BookPackage> bookedPackages = new List<BookPackage>();
            try
            {
                if (emailId != null)
                {
                    bookedPackages = (from packages in this.dbContext.BookPackages
                                      where packages.EmailId == emailId
                                      select packages).ToList();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Some error occured");
                bookedPackages = null;
            }
            return bookedPackages;
        }
    }

}
