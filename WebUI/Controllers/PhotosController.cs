using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        private readonly IPhotoUploadService _photoUploadService;

        public PhotosController(IPhotoService photoService, IPhotoUploadService photoUploadService)
        {
            _photoService = photoService;
            _photoUploadService = photoUploadService;
        }
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadImage([FromForm] Photo photo)
        {
            List<Core.Utilities.Results.IResult> results = new List<Core.Utilities.Results.IResult>();
            foreach (IFormFile file in Request.Form.Files)
            {
                Core.Utilities.Results.IResult imageResult = await _photoUploadService.UploadImageAsync(file, photo);
                if (imageResult.IsSuccess == false)
                {
                    results.Add(imageResult);
                }
            }
            if (results.Count == 0)
            {
                results.Add(new SuccessResult("Resimler başarıyla yüklenmiştir"));
            }
            return Ok(results);
        }
    }
}
