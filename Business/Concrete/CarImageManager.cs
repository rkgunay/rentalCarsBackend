using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckImageLimit(carImage.CarId));
            if (result != null)
            {
                var resultNull = CheckNullImage(carImage.CarImageId);
                if(resultNull != null)
                {
                    return resultNull;
                }
                return result;
            }

            carImage.CarImagePath = FileHelper.Add(formFile).Message;
            carImage.CarImageDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == id));
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == id));
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var isImage = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (isImage == null)
            {
                return new ErrorResult("Resim bulunamadı");
            }

            var updatedFile = FileHelper.Update(formFile, isImage.CarImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.CarImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult("Araba resmi güncellendi");
        }


        private IResult CheckImageLimit(int id)
        {
            var carImageCount = _carImageDal.GetAll(c => c.CarId == id).Count;
            if (carImageCount > 5)
            {
                return new ErrorResult(Messages.LimitExceeded);
            }
            return new SuccessResult();
        }


        private IDataResult<List<CarImage>> CheckNullImage(int id)
        {
            try
            {
                string path = @"\CarImages\default.jpg";
                var carImageCount = _carImageDal.GetAll(c => c.CarId == id).Any();
                if (!carImageCount)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = id, CarImagePath = path, CarImageDate = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));


        }

    }

}

