using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTvDal : EfEntityRepositoryBase<Tv, TvProjectContext>, ITvDal
    {
        public async Task<List<Photo>> GetPhotos(int tvId)
        {
            using(var context = new TvProjectContext())
            {
                var result = from tvPhoto in context.TvPhotos
                             join photos in context.Photos
                             on tvPhoto.PhotoId equals photos.Id
                             where tvPhoto.TvId == tvId
                             select new Photo
                             {
                                 ImageUrl = photos.ImageUrl,
                                 IsMain = photos.IsMain
                             };
                return await result.ToListAsync();
            }
        }
    }
}
