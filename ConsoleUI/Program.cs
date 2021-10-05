using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //TestBrands();
            // TestColors();
            //TestCars();
            //TestUsers();
           // TestCustomers();
            TestRentals();
        }

        private static void TestRentals()
        {

            Rental rental1 = new Rental
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2021, 10, 5)
            };
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.RentalId + " :" + rental.RentDate);
            }
        }

        private static void TestCustomers()
        {
            Customer customer1 = new Customer
            {
                UserId = 1,
                CompanyName = "Little Software Inc."
            };
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void TestUsers()
        {
            User user1 = new User { 
         
                FirstName = "Rıdvan",
                LastName = "Günay",
                Email = "ridvankgunay@gmail.com",
                Password = "123456"
            };
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName  +user.LastName);
            }

        }

        private static void TestCars()
        {
            Car car1 = new Car
            {
                Name = "Honda 5.Seri",
                BrandId = 1,
                ColorId = 4,
                DailyPrice = 1590,
                Description = "OTV indirimli araçlar, uygun ödeme şartları.",
                ModelYear = "2021"
            };
            Car car2 = new Car
            {
                Name = "Audi 3.Seri",
                BrandId = 2,
                ColorId = 2,
                DailyPrice = 1100,
                Description = "Honda Civic ailesinin en yeni üyesi. ",
                ModelYear = "2021"
            };
            Car car3 = new Car
            {
                Name = "BMW 5.Seri",
                BrandId = 4,
                ColorId = 3,
                DailyPrice = 1490,
                Description = "Yeni BMW Sizlerle.",
                ModelYear = "2021"
            };

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
            carManager.Add(car2);
            carManager.Add(car3);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Name);
            }


        }

        private static void TestBrands()
        {
   

        }

        private static void TestColors()
        {
        

        }

        


    }

   
}
