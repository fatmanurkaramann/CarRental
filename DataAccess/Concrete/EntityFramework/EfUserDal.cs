﻿using Core.Concrete.Entities;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,CarAppDbContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CarAppDbContext())
            {
                var result = from operationClaim in context.OPERATİONCLAİMS
                             join userOperationClaim in context.USEROPERATİONCLAİMS
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
