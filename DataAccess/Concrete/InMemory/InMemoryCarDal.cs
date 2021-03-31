using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=100000, ModelYear="2018", Description="TOYOTA COROLLA"},
            new Car{Id=2, BrandId=2, ColorId=2, DailyPrice=200000, ModelYear="2019", Description="FIAT LINEA"},
            new Car{Id=3, BrandId=3, ColorId=3, DailyPrice=300000, ModelYear="2020", Description="BMW 320"},
            new Car{Id=4, BrandId=4, ColorId=4, DailyPrice=400000, ModelYear="2021", Description="MERCEDES E200"}
            };
        }

        public void Add(Car car)
            {
                _cars.Add(car);

            }

            public void Delete(Car car)
            {
                Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
                _cars.Remove(carToDelete);

            }

            public List<Car> GetAll()
            {
                return _cars;
            }

            public List<Car> GetById(int Id)
            {
                return _cars.Where(c => c.Id == Id).ToList();
            }

            public void Update(Car car)
            {
                Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
                carToUpdate.Id = car.Id;
                carToUpdate.ModelYear = car.ModelYear;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.ColorId = car.ColorId;
                carToUpdate.Description = car.Description;
                carToUpdate.BrandId = car.BrandId;

            }
        }

        
    
}