using Business.Concrete;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetCarsByBrandId();
            //GetCarsByColorId();
            //CarAdd();
            //DescriptionTest();
            //BrandTest();
            //CarTest();
            //ColorTest();
            
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color
            {
                ColorName = "SARI"
            };
            colorManager.Add(color);
            foreach (var colors in colorManager.GetAll())
            {
                Console.WriteLine(colors.ColorName);
            }
            colorManager.Update(color);
            Console.WriteLine("RENK GNCELLENDİ");
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car
            {
                Id = 5
            };
            carManager.Add(new Car { BrandId = 5, ColorId = 5, ModelYear = "2021", DailyPrice = 500, Description = "OPEL CORSA" });
            foreach (var cars in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} / {1} / {2} / {3}", cars.CarName, cars.BrandName, cars.ColorName, cars.ColorId);
            }
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);
            }
            carManager.Delete(car1);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetBrandDetails())
            {
                Console.WriteLine(brand.BrandId + "/" + brand.BrandName);
            }
        }

        private static void DescriptionTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);
            }
        }
        static void GetCars()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("ARAÇ KİRALAMA SİSTEMİNE HOŞGELDİNİZ!");
            Console.WriteLine("*******MEVCUT ARAÇLAR*******");
            foreach (var cars in carManager.GetAll())
           {
                Console.WriteLine("ARABA MODELİ: " + cars.Description);
                Console.WriteLine("GÜNLÜK FİYATI:" + cars.DailyPrice);
                Console.WriteLine("MODEL YILI:" + cars.ModelYear);
                Console.WriteLine("***************************");
           }
       }
       static void GetCarsByBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
           Console.WriteLine("MARKA SEÇİN: 1:TOYOTA 2:FIAT 3:BMW 4:MERCEDES");
            int markaSecim = Convert.ToInt32(Console.ReadLine());
            foreach (var cars in carManager.GetCarsByBrandId(markaSecim))
            {
               Console.WriteLine(cars.Description);
            }
       }


        static void GetCarsByColorId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("RENK SEÇİN: 1:BEYAZ 2:SİYAH 3:KIRMIZI 4:MAVİ");
            int renkSecim = Convert.ToInt32(Console.ReadLine());
            foreach (var cars in carManager.GetCarsByColorId(renkSecim))
            {
                Console.WriteLine(cars.Description);
            }
        }

        static void CarAdd()
        {
            Car car = new Car();
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("EKLEMEK İSTEDİĞİNİZ ARACIN ID NUMARASINI GİRİNİZ:");
            car.Id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("EKLEMEK İSTEDİĞİNİZ ARACIN BRAND ID NUMARASINI GİRİNİZ:");
           car.BrandId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("EKLEMEK İSTEDİĞİNİZ ARACIN COLOR ID NUMARASINI GİRİNİZ:");
          car.ColorId = Convert.ToInt32(Console.ReadLine());

           Console.WriteLine("EKLEMEK İSTEDİĞİNİZ ARACIN GÜLÜK KİRALAMA ÜCRETİNİ GİRİNİZ:");
           car.DailyPrice = Convert.ToInt32(Console.ReadLine());

           Console.WriteLine("EKLEMEK İSTEDİĞİNİZ ARACIN MODEL YILINI GİRİNİZ:");
           car.ModelYear = Convert.ToString(Console.ReadLine());

           Console.WriteLine("EKLEMEK İSTEDİĞİNİZ ARACIN MARKA VE MODELİNİ GİRİNİZ:");
           car.Description = Convert.ToString(Console.ReadLine());

           carManager.Add(car);
        }
    }
}
