using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<List<Car>> GetCarsByBrandId(int id);

        IDataResult<List<Car>> GetAllById(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        DataResult<List<Car>> GetByDailyPrice();
        DataResult<List<Car>> GetByMonthlyPrice();
        DataResult<List<Car>> GetByYearlyPrice();
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult Add(Car cars);
        IResult Delete(Car cars);
        IResult Update(Car cars);
    }
}
