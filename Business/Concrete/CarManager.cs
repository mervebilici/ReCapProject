using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
            }
            else
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
           
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(Messages.CarsListed);
           
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

       

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        IDataResult<List<CarDetailDto>> ICarService.GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        IDataResult<Car> ICarService.GetCarsByBrandId(int brandId)
        {

            return new SuccessDataResult<Car>(_carDal.Get(b => b.BrandId == brandId), Messages.CarsListed);
        }

        IDataResult<Car> ICarService.GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.ColorId == colorId), Messages.CarsListed);
        }

        IDataResult<Car> ICarService.GetCarsByDailyPrice(int dailyPrice)
        {
            return new SuccessDataResult<Car>(_carDal.Get(d => d.DailyPrice == dailyPrice), Messages.CarsListed);

        }
    }
}
