using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Infosys.TravelAwayDAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infosys.TravelAwayDAL.TravelAwayRepository
{
    public class RegisterUserRepositiory
    {

        public TravelAwayDBContext Context { get; set; }
        public RegisterUserRepositiory(TravelAwayDBContext context){
            Context = context;
            }

        public int RegisterNewCustomer(string EmailId,byte? RoleId, string FirstName, string LastName, decimal ContactNumber,
                    string Address, DateTime DateOfBirth, string Gender, string UserPassword)
        {      
            int result;
            try
            {
                SqlParameter prmFirstName = new SqlParameter("@firstName", FirstName);
                SqlParameter prmLastName = new SqlParameter("@lastName", LastName);
                SqlParameter prmPassword = new SqlParameter("@userPassword", UserPassword);
                SqlParameter prmGender = new SqlParameter("@gender", Gender);
                SqlParameter prmEmailId = new SqlParameter("@emailId", EmailId);
                SqlParameter prmDob = new SqlParameter("@dateOfBirth", DateOfBirth);
                SqlParameter prmNumber = new SqlParameter("@contactNumber", ContactNumber);
                SqlParameter prmAddress = new SqlParameter("@address", Address);
                SqlParameter prmReturnResult = new SqlParameter("@ReturnResult", System.Data.SqlDbType.Int);
                prmReturnResult.Direction = System.Data.ParameterDirection.Output;
                result = Context.Database.ExecuteSqlRaw("EXEC @ReturnResult= usp_RegisterCustomer @emailId,@firstName,@lastName,@userPassword, " +
                    "@gender,@contactNumber,@dateOfBirth,@address",
                    prmReturnResult, prmEmailId, prmFirstName, prmLastName, prmPassword, prmGender, prmNumber, prmDob, prmAddress);
                if (result > 0)
                {
                    return result;
                }
                else
                {
                  result = -98;
                    return result;
                }
            }
            catch (Exception )
            {
                result = -99;
                return result;
            }
        }
    }
}
