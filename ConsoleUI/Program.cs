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
            //CarAdd();
            GetCars();
            //CarDetailsTest();

            //CustomersTest();
            //UsersTest();
            //RentalsTest();
        }

        private static void RentalsTest()
        {
            RentalsManager rentalsManager = new RentalsManager(new EfRentalsDal());

            Console.WriteLine(rentalsManager.Add(new Rentals()
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2021, 03, 30)
            }).Message);
        }

        private static void UsersTest()
        {
            UsersManager usersManager = new UsersManager(new EfUsersDal());
            usersManager.Add(new Users()
            {
                FirstName = "Selin",
                LastName = "Berber",
                Email = "selinberber@gmail.com",
                Id = 2
            });
            usersManager.Add(new Users()
            {
                FirstName = "Ecem Sena",
                LastName = "Çelik",
                Email = "ecemçelik@gmail.com",
                Id = 3
            });
            usersManager.Add(new Users()
            {
                FirstName = "Muhammeed Eymen",
                LastName = "Bayram",
                Email = "eymenbayram@gmail.com",
                Id = 4
            });
            Console.WriteLine("*********************KULLANICILAR LİSTESİ******************");
            foreach (var user in usersManager.GetAll().Data)
            {
                Console.WriteLine("{0} : {1} : {2} : {3} : {4}", user.Id, user.FirstName, user.LastName, user.Email, user.Password);
            }
            usersManager.Delete(new Users()
            {
                Id = 3
            });
            Console.WriteLine("*********************KULLANICILAR LİSTESİ******************");
            foreach (var user in usersManager.GetAll().Data)
            {
                Console.WriteLine("{0} : {1} : {2} : {3} : {4}", user.Id, user.FirstName, user.LastName, user.Email, user.Password);
            }
            usersManager.Update(new Users()
            {
                Id = 2,
                FirstName = "Edanur",
                LastName = "Bayram",
                Email = "edanurbayram@gmail.com",
            });
            Console.WriteLine("*********************KULLANICILAR LİSTESİ******************");
            foreach (var user in usersManager.GetAll().Data)
            {
                Console.WriteLine("{0} : {1} : {2} : {3} : {4}", user.Id, user.FirstName, user.LastName, user.Email, user.Password);
            }
        }

        private static void CustomersTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomersDal());
            Console.WriteLine(customerManager.Add(new Customers
            {
                UserId = 1,
                CompanyName = "A AJANS"

            }));
            customerManager.Add(new Customers
            {
                UserId = 2,
                CompanyName = "B AJANS"
            });
            customerManager.Add(new Customers
            {
                UserId = 3,
                CompanyName = "C AJANS"
            });
            Console.WriteLine("*********************MÜŞTERİ LİSTESİ********************");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine("{0} : {1} ", customer.UserId, customer.CompanyName);
            }

            customerManager.Delete(new Customers()
            {
                UserId = 3
            });

            Console.WriteLine("------------------MÜŞTERİ LİSTESİ-------------------------");

            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine("{0} : {1} ", customer.UserId, customer.CompanyName);
            }
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.Description + "/ " + car.ColorName + "/ " + car.ColorId + "/ "
                    + car.BrandName + "/ " + car.BrandId + "/ " + car.DailyPrice);
            }
        }

        private static void GetCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("ARAÇ KİRALAMA SİSTEMİNE HOŞGELDİNİZ!");
            Console.WriteLine("*******MEVCUT ARAÇLAR*******");
            foreach (var cars in carManager.GetAll().Data)
            {
                Console.WriteLine("ARABA MODELİ: " + cars.Description);
                Console.WriteLine("GÜNLÜK FİYATI:" + cars.DailyPrice);
                Console.WriteLine("MODEL YILI:" + cars.ModelYear);
                Console.WriteLine("***************************");
            }
        }


        private static void CarAdd()
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