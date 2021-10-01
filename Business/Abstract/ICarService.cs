using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(string id);
        List<Car> GetCarsByColorId(string id);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}
