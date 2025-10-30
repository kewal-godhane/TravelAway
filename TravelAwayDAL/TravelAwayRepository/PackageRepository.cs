using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infosys.TravelAwayDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Infosys.TravelAwayDAL.TravelAwayRepository
{
    public class PackageRepository
    {
        public TravelAwayDBContext Context { get; set; }

        public PackageRepository(TravelAwayDBContext context)
        {
            Context = context;
        }

        public List<Package> GetPackages()
        {
            List<Package> package;
            try
            {
                package = (from a in Context.Packages select a).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                package = null;
            }
            return package;
        }

        public List<PackageCategory> GetPackageCategories()
        {
            {
                List<PackageCategory> obj = null;
                try
                {
                    obj = (from a in Context.PackageCategories select a).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    obj = null;
                }
                return obj;
            }

        }
    }
}
