using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infosys.TravelAwayDAL.Models;

namespace Infosys.TravelAwayDAL.TravelAwayRepository
{
    public class ReportsRepository
    {
        public TravelAwayDBContext Context { get; set; }

        public ReportsRepository(TravelAwayDBContext context)
        {
            Context = context;
        }

        public List<Object> packageCountByCateory()
        {
            var result = new List<Object>();
            try
            {
                result = Context.PackageCategories.Join(Context.Packages, p => p.PackageCategoryId, c => c.PackageCategoryId, (c, p) => new { c, p }).GroupBy(x => x.c.PackageCategoryName).Select(g => new
                {
                    CategoryName = g.Key,
                    PackageCount = g.Count()
                }).ToList<object>();
            }
            catch (Exception e)
            {
                Console.WriteLine("p");
                Console.WriteLine(e.Message);
                Console.WriteLine("t");

            }
            return result;
        }

        public List<Object> BookingCountByPackage()
        {
            var result = new List<Object>();
            try
            {
                result = Context.BookPackages.Join(Context.PackageDetails, b => b.PackageId, pd => pd.PackageDetailsId, (b, pd) => new { b, pd }) // First join: Booking → PackageDetails
               .Join(Context.Packages,

                   bp => bp.pd.PackageId,

                   p => p.PackageId,

                   (bp, p) => new { bp, p }) // Second join: PackageDetails → Packages

                   .GroupBy(x => x.p.PackageName) // Group by PackageName

                   .Select(g => new
                   {
                       PackageName = g.Key, // GroupBy on PackageName
                       BookingCount = g.Count()
                   })

                   .ToList<object>(); // Convert to a List<object> for API return
            }
            catch (Exception e)
            {
                Console.WriteLine("p");
                Console.WriteLine(e.Message);
                Console.WriteLine("t");

            }
            return result;
        }
    }
}
