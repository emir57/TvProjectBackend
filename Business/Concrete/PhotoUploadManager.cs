using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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
        public async Task<IResult> UploadImageAsync(IFormFile file,int tvId)
        {
            string dataBasePath = "";
            FileUploadHelper.Upload(file, out dataBasePath);
            var image = new Photo() { ImageUrl = dataBasePath,TvId=tvId };
            await _photoService.Add(image);
            return new SuccessResult(Messages.UploadImage);
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
