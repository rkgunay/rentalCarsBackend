using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                
                var result = from ca in context.Cars
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId 
                             join img in context.CarImages
                             on ca.CarId equals img.CarId

                             select new CarDetailDto 
                             {

                                 Id = ca.CarId,
                                 ColorId = ca.ColorId,
                                 BrandId = ca.BrandId,
                                 Name = ca.Name,
                                 ColorName = co.ColorName,
                                 BrandName = br.BrandName,
                                 DailyPrice = ca.DailyPrice,
                                 ModelYear = ca.ModelYear,
                                 ImagePath = img.CarImagePath,
                                 Description = ca.Description
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
