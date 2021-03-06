using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PhotoUploadManager : IPhotoUploadService
    {
        private readonly IPhotoService _photoService;
        public PhotoUploadManager(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        public async Task<IResult> UploadImageAsync(IFormFile file,Photo photo)
        {
            IResult result = BusinessRules.Run(
                await IsMainExistsCheck(photo)
                );
            if(result != null)
            {
                return result;
            }
            string dataBasePath = "";
            FileUploadHelper.Upload(file, out dataBasePath);
            //var image = new Photo() { ImageUrl = dataBasePath,TvId=tvId };
            photo.ImageUrl = dataBasePath;
            photo.Id = 0;
            await _photoService.AddAsync(photo);
            return new SuccessResult(Messages.UploadImage);
        }

        private async Task<IResult> IsMainExistsCheck(Photo photo)
        {
            IDataResult<List<Photo>> photos = await _photoService.GetListByTvIdAsync(photo.TvId);
            if (photos.Data.Any(x => x.IsMain == true) && photo.IsMain)
            {
                return new ErrorResult(Messages.IsMainExists);
            }
            return new SuccessResult();
        }

        //public async Task<IResult> UploadImageAsync(IFormFile file)
        //{
        //    string dataBasePath = "";
        //    FileUploadHelper.Update(file, out dataBasePath);
        //    var image = new Photo() { ImageUrl = dataBasePath };
        //    await _photoService.Add(image);
        //}
    }
}
