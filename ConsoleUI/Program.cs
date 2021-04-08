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
            CarAdd();
            //GetCars();
            //CarDetailsTest();

            //CustomersTest();
            //UsersTest();
            //RentalsTest();
        }

        private static void RentalsTest()
        {
            RentalManager rentalsManager = new RentalManager(new EfRentalsDal());

            rentalsManager.Add(new Rental()
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2021, 3, 3)
            });
            foreach (var rental in rentalsManager.GetAll().Data)
            {
                Console.WriteLine("{0} : {1} : {2} : {3}", rental.Id ,rental.CarId, rental.CustomerId, rental.RentDate);
            }
        }

        private static void UsersTest()
        {
            UserManager usersManager = new UserManager(new EfUsersDal());
            usersManager.Add(new User()
            {
                FirstName = "Selin",
                LastName = "Berber",
                Emaiil = "selinberber@gmail.com",

                Password = "12345"
            });

            usersManager.Add(new User()
            {
                FirstName = "Ecem Sena",
                LastName = "Çelik",
                Emaiil = "ecemçelik@gmail.com",

                Password = "1234"
            });

            usersManager.Add(new User()
            {
                FirstName = "Muhammeed Eymen",
                LastName = "Bayram",
                Emaiil = "eymenbayram@gmail.com",

                Password = "123"
            });

            Console.WriteLine("*********************KULLANICILAR LİSTESİ******************");
            foreach (var user in usersManager.GetAll().Data)
            {
                Console.WriteLine("{0} : {1} : {2} : {3} : {4}", user.Id, user.FirstName, user.LastName, user.Emaiil, user.Password);
            }
            Console.WriteLine(usersManager.Delete(new User
            {
                Id = 1
            }).Message );

            Console.WriteLine("*********************KULLANICILAR LİSTESİ******************");
            foreach (var user in usersManager.GetAll().Data)
            {
                Console.WriteLine("{0} : {1} : {2} : {3} : {4}", user.Id, user.FirstName, user.LastName, user.Emaiil, user.Password);
            }

            usersManager.Update(new User()
            {
                Id = 3,
                FirstName = "Edanur",
                LastName = "Bayram",
                Emaiil = "edanurbayram@gmail.com",
                Password = "123456"
            });
            Console.WriteLine("*********************KULLANICILAR LİSTESİ******************");

            foreach (var user in usersManager.GetAll().Data)
            {
                Console.WriteLine("{0} : {1} : {2} : {3} : {4}", user.Id, user.FirstName, user.LastName, user.Emaiil, user.Password);
            }
        }

        private static void CustomersTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomersDal());
            Console.WriteLine(customerManager.Add(new Customer
            {
                UserId = 1,
                CompanyName = "A AJANS"

            }));
            customerManager.Add(new Customer
            {
                UserId = 2,
                CompanyName = "B AJANS"
            });
            customerManager.Add(new Customer
            {
                UserId = 3,
                CompanyName = "C AJANS"
            });
            Console.WriteLine("*********************MÜŞTERİ LİSTESİ********************");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine("{0} : {1} : {3} ", customer.Id, customer.UserId, customer.CompanyName);
            }

            customerManager.Delete(new Customer
            {
                Id = 1
            });
            Console.WriteLine("*********************MÜŞTERİ LİSTESİ********************");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine("{0} : {1} : {3} ", customer.Id, customer.UserId, customer.CompanyName);
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

            Console.WriteLine("EKLEMEK İSTEDİĞİNİZ ARACIN AYLIK KİRALAMA ÜCRETİNİ GİRİNİZ:");
            car.DailyPrice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("EKLEMEK İSTEDİĞİNİZ ARACIN YILLIK KİRALAMA ÜCRETİNİ GİRİNİZ:");
            car.DailyPrice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("EKLEMEK İSTEDİĞİNİZ ARACIN MODEL YILINI GİRİNİZ:");
            car.ModelYear = Convert.ToString(Console.ReadLine());

            Console.WriteLine("EKLEMEK İSTEDİĞİNİZ ARACIN MARKA VE MODELİNİ GİRİNİZ:");
            car.Description = Convert.ToString(Console.ReadLine());

            carManager.Add(car);
        }
    }
}