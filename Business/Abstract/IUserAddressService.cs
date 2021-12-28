﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserAddressService 
    {
        Task<IResult> Add(UserAddress userAddress);
        Task<IResult> Delete(UserAddress userAddress);
        Task<IResult> Update(UserAddress userAddress);
        Task<IDataResult<List<UserAddress>>> GetByUserId(int userId);
        Task<IDataResult<List<UserAddress>>> GetAll(Expression<Func<UserAddress,bool>> filter=null);
        Task<IDataResult<UserAddress>> Get(Expression<Func<UserAddress,bool>> filter);
        Task<IDataResult<List<UserAddressCityDto>>> GetByCityName(Expression<Func<UserAddressCityDto, bool>> filter);

    }
}
