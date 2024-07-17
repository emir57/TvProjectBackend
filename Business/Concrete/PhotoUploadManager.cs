using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<Core.Utilities.Results.IResult> UploadImageAsync(IFormFile file, Photo photo)
        {
            Core.Utilities.Results.IResult result = BusinessRules.Run(
                await IsMainExistsCheck(photo)
                );
            if (result != null)
                return result;

            FileUploadHelper.Upload(file, out string dataBasePath);

            photo.ImageUrl = dataBasePath;
            photo.Id = 0;

            await _photoService.AddAsync(photo);
            return new SuccessResult(Messages.UploadImage);
        }

        private async Task<Core.Utilities.Results.IResult> IsMainExistsCheck(Photo photo)
        {
            IDataResult<List<Photo>> photos = await _photoService.GetListByTvIdAsync((int)photo.TvId);
            if (photos.Data.Any(x => x.IsMain == true) && photo.IsMain)
                return new ErrorResult(Messages.IsMainExists);

            return new SuccessResult();
        }
    }
}
