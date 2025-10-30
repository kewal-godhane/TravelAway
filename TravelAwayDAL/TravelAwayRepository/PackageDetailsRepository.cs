using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infosys.TravelAwayDAL.Models;

namespace Infosys.TravelAwayDAL.TravelAwayRepository
{
    public class PackageDetailsRepository
    {
        private TravelAwayDBContext dbContext;

        public PackageDetailsRepository(TravelAwayDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<PackageDetail> GetPackageDetails(int packageId)
        {
            var packages = new List<PackageDetail>();
            try
            {
                packages = (from packageDetail in dbContext.PackageDetails
                            where packageDetail.PackageId == packageId
                            select packageDetail).ToList();
                if (packages == null)
                {
                    packages = null;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Some errror occured");
            }
            return packages;
        }

    }
}
