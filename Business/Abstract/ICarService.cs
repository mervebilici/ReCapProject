using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService: IService<Car>
    {
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
        List<Car> GetCarsByDailyPrice(int dailyPrice);
       

        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}
