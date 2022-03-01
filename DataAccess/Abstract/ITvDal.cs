﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITvDal:IEntityRepository<Tv>
    {
        Task<List<Photo>> GetPhotos(int tvId);
        Task<List<TvAndPhotoDto>> GetTvWithPhotos(Expression<Func<TvAndPhotoDto, bool>> filter=null);
        Task<List<TvAndPhotoDetailDto>> GetTvDetails(Expression<Func<TvAndPhotoDetailDto, bool>> filter = null);
        Task<TvAndPhotoDetailDto> GetTvDetail(Expression<Func<TvAndPhotoDetailDto, bool>> filter);
    }
}
