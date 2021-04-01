using Business.Concrete;
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
            GetCarsByColorId();
           // CarAdd();

            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var cars in carManager.GetAll())
            //{
            //    Console.WriteLine(cars.Description);
            //}
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
