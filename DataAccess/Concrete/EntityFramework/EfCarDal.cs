using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context =new CarRentalContext())
            {
                var result = from m in context.Cars
                             join b in context.Brands
                             on m.BrandId equals b.BrandId
                             join c in context.Colors
                             on m.ColorId equals c.ColorId
                             select new CarDetailDto
                             {
                                 CarName = m.Description,
                                 ColorId = m.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName
                                  
                             };
                return result.ToList();
            }
        }
    }
}
