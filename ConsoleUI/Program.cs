using Business.Concrete;
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
                Description = "Yeni geldi bu araba.",
                ModelYear = "2021"
            };
     
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("****Tüm araçlar Listelendi \n");
            carManager.ListAllCars();

            carManager.Add(car1);
            Console.WriteLine("****5 id'li 2021 model araba eklendi. \n");
            carManager.ListAllCars();

            car1.Description = "Yeni geldi bu araba. 3 Yıllık.";
            car1.ModelYear = "2019";

            carManager.Update(car1);
            Console.WriteLine("****5 id'li araba güncellendi. \n");
            carManager.ListAllCars();

            carManager.Delete(car1);
            Console.WriteLine("****5 id'li 2021 model araba silindi. \n");
            carManager.ListAllCars();

        

            carManager.GetById(3);
            Console.WriteLine("****Id ile araba getirildi. Doblo olan. \n");
            carManager.ListAllCars();
        }
    
    }

   
}
