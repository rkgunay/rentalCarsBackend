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
            Car car1 = new Car {
                Id = 5,
                BrandId = "2",
                ColorId = "4",
                DailyPrice = 1590,
                Description = "Honda",
                ModelYear = "2021"
            };
                Car car2= new Car {
                Id = 6,
                BrandId = "2",
                ColorId = "4",
                DailyPrice = -15,
                Description = "Honda",
                ModelYear = "2021"
            };

            CarManager carManager = new CarManager(new EfCarDal());

            //DailyPrice 0'dan küçük olduğu için hata verecek.
            carManager.Add(car2);
            
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id);
                Console.WriteLine(car.Description);
            }     
            foreach (var car in carManager.GetCarsByBrandId("2"))
            {
                Console.WriteLine(car.Description);
                Console.WriteLine(car.BrandId);
            }
             foreach (var car in carManager.GetCarsByColorId("4"))
            {
                Console.WriteLine(car.Description);
                Console.WriteLine(car.ColorId);
            }



        }
    
    }

   
}
