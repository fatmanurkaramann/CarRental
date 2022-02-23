using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarAppDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarAppDbContext context= new CarAppDbContext())
            {
                var result = from c in context.CARS
                             join b in context.BRANDS

                             on c.BrandId equals b.BrandId
                             join co in context.COLORS
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto { CarName = c.CarName, ColorName = co.ColorName, BrandName = b.BrandName, DailyPrice = c.DailyPrice };

                return result.ToList();
            }
        }
    }
}
