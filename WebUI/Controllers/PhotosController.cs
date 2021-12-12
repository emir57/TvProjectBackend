using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadImage([FromForm]Photo photo,[FromForm]IFormFile file)
        {
            Thread.Sleep(1);
            string databasePath = "";
            FileUploadHelper.Upload(file, out databasePath);
            photo.ImageUrl = databasePath;
            var result = await _photoService.Add(photo);
            if (!result.IsSuccess)
            {
                return BadRequest(new ErrorResult("Resim Yükleme Başarısız"));
            }
            return Ok(new SuccessResult("Resim Yükleme Başarılı"));
        }
    }
}
