using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        public int CarImageId { get; set; }
        public int CarId { get; set; }
        public string CarImagePath { get; set; }
        public DateTime CarImageDate { get; set; }

        public CarImage()
        {
            CarImageDate = DateTime.Now;
        }
    }
}
