using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _inMemoryCarDal;
        public CarManager(ICarDal inMemoryCarDal)
        {
            _inMemoryCarDal = inMemoryCarDal;
        }

        public void Add(Car car)
        {
            _inMemoryCarDal.Add(car);
        }

        public void Delete(Car car)
        {
            _inMemoryCarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _inMemoryCarDal.GetAll();
        }

        public List<Car> GetById(int Id)
        {
            return _inMemoryCarDal.GetById(Id);
        }

        public void Update(Car car)
        {
            _inMemoryCarDal.Update(car);
        }

        public void ListAllCars()
        {
            foreach (var car in _inMemoryCarDal.GetAll())
            {
                Console.WriteLine("Id : " +car.Id);
                Console.WriteLine("Marka: " +car.BrandId);
                Console.WriteLine("Renk Id'si: " +car.ColorId);
                Console.WriteLine("Günlük Ücreti : " +car.DailyPrice);
                Console.WriteLine("Model Yılı : " +car.ModelYear);
                Console.WriteLine("Açıklama : " +car.Description);
                Console.WriteLine("\n");
            }
        }

        public void GetCarById(int Id)
        {
            List<Car> car = GetById(Id);
            Console.WriteLine("Id : " + car[0].Id);
            Console.WriteLine("Marka: " + car[0].BrandId);
            Console.WriteLine("Renk Id'si: " + car[0].ColorId);
            Console.WriteLine("Günlük Ücreti : " + car[0].DailyPrice);
            Console.WriteLine("Model Yılı : " + car[0].ModelYear);
            Console.WriteLine("Açıklaması " + car[0].Description);
        }
    }
}
