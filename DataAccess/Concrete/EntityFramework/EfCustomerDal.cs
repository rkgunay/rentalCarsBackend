using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {

                var result = from cu in context.Customers
                             join us in context.Users
                             on  cu.UserId equals us.Id

                             select new CustomerDetailDto
                             {
                                 CustomerId = cu.CustomerId,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 Email = us.Email,
                                 CompanyName = cu.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
