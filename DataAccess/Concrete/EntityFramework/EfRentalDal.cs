using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarAppDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (var context = new CarAppDbContext())
            {
                var result = from r in context.RENTALS

                             join c in context.CARS
                             on r.CarId equals c.Id

                             join b in context.BRANDS
                             on c.BrandId equals b.BrandId

                             join cr in context.CUSTOMERS
                             on r.CustomerId equals cr.Id

                             join u in context.USERS
                             on cr.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 BrandName = b.BrandName,
                                 CarId =c.Id,
                                 CustomerId = r.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 ModelYear=c.ModelYear
                                 
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
