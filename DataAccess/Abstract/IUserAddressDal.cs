﻿using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserAddressDal:IEntityRepository<UserAddress>
    {
        Task<List<UserAddressCityDto>> GetAddressByCityName(Expression<Func<UserAddressCityDto, bool>> filter);
    }
}
