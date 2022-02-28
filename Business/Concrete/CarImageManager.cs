using Business.Abstract;
using Business.Constants;
using Core.Helpers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage,IFormFile file)
        {
            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            IResult result = BusinessRules.Run(CheckImageCount(carImage));
            if (result!=null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(CarImage carImage)
        {
            return new SuccessResult();
        }
        private IResult CheckImageCount(CarImage carImage)
        {
            var imageCount = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;
            if (imageCount>5)
            {
                return new ErrorResult(Messages.ImageCountError);
            }
            return new SuccessResult();
        }
    }
}
