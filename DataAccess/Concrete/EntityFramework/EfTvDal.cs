﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Dtos;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTvDal : EfEntityRepositoryBase<Tv, TvProjectContext>, ITvDal
    {
        public async Task<List<Photo>> GetPhotos(int tvId)
        {
            using(var context = new TvProjectContext())
            {
                var result = from tvPhoto in context.Photos
                             join tv in context.Tvs
                             on tvPhoto.TvId equals tv.Id
                             where tvPhoto.TvId == tvId
                             select new Photo
                             {
                                 ImageUrl = tvPhoto.ImageUrl,
                                 IsMain = tvPhoto.IsMain
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<TvAndPhotoDetailDto> GetTvDetails(int tvId)
        {
            using(var context = new TvProjectContext())
            {
                var result = await context.Tvs.Select(t=>
                             new TvAndPhotoDetailDto
                             {
                                 Id = t.Id,
                                 ProductName = t.ProductName,
                                 ProductCode = t.ProductCode,
                                 ScreenType = t.ScreenType,
                                 ScreenInch = t.ScreenInch,
                                 Extras = t.Extras,
                                 UnitPrice = t.UnitPrice,
                                 BrandId = t.BrandId,
                                 Discount = t.Discount,
                                 IsDiscount = t.IsDiscount,
                                 Photos = context.Photos
                                        .Where(p => p.TvId == tvId)
                                        .ToList()
                            }).SingleOrDefaultAsync(tv => tv.Id == tvId);
                return result;
            }
        }
        public async Task<List<TvAndPhotoDto>> GetTvWithPhotos()
        {
            using (var context = new TvProjectContext())
            {
                var result = from tvs in context.Tvs
                             join photos in context.Photos
                             on tvs.Id equals photos.TvId
                             where photos.IsMain == true
                             select new TvAndPhotoDto
                             {
                                 Id = tvs.Id,
                                 ProductName = tvs.ProductName,
                                 ProductCode = tvs.ProductCode,
                                 ScreenType = tvs.ScreenType,
                                 ScreenInch = tvs.ScreenInch,
                                 Extras = tvs.Extras,
                                 UnitPrice = tvs.UnitPrice,
                                 BrandId = tvs.BrandId,
                                 Discount = tvs.Discount,
                                 IsDiscount = tvs.IsDiscount,
                                 ImageUrl = photos.ImageUrl
                             };
                return await result.ToListAsync();

            }
        }
        public async Task<List<TvAndPhotoDto>> GetTvWithPhotos(Expression<Func<TvAndPhotoDto,bool>> filter)
        {
            using (var context = new TvProjectContext())
            {
                var result = from tvs in context.Tvs
                             join photos in context.Photos
                             on tvs.Id equals photos.TvId
                             where photos.IsMain==true
                             select new TvAndPhotoDto
                             {
                                 Id=tvs.Id,
                                 ProductName = tvs.ProductName,
                                 ProductCode = tvs.ProductCode,
                                 ScreenType = tvs.ScreenType,
                                 ScreenInch = tvs.ScreenInch,
                                 Extras = tvs.Extras,
                                 UnitPrice = tvs.UnitPrice,
                                 BrandId = tvs.BrandId,
                                 Discount = tvs.Discount,
                                 IsDiscount = tvs.IsDiscount,
                                 ImageUrl = photos.ImageUrl
                             };
                return await result.Where(filter).ToListAsync();
                    
            }
        }
    }
}
