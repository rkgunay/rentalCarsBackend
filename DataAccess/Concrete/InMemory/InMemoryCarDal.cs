using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car
                {
                    Name = "Mercedes Benz Premium Model",
                    BrandId = 1,
                    ColorId = 1,
                    DailyPrice = 600,
                    Description = "Temiz arazi aracı",
                    ModelYear = "2005"
                }, 
                new Car
                {
                    Name = "Rolls Royce ATX 3.52",
                    BrandId = 1,
                    ColorId = 3,
                    DailyPrice = 1700,
                    Description = "Spor araba",
                    ModelYear = "2018"
                }, 
                new Car
                {
                    Name = "Renault Doblo",
                    BrandId = 3,
                    ColorId = 4,
                    DailyPrice = 500,
                    Description = "Enişteler için temiz Doblo",
                    ModelYear = "2004"
                }, 
                new Car
                {
                    Name = "Sweather Wheather Klibindeki Araba",
                    BrandId = 2,
                    ColorId = 4,
                    DailyPrice = 900,
                    Description = "Bu arabayla sahilde bir gezin derim",
                    ModelYear = "2016"
                },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.CarId == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;

            
        }
    }
}
