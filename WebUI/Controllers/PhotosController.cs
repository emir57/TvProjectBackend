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
        private readonly IPhotoUploadService _photoUploadService;

        public PhotosController(IPhotoService photoService,IPhotoUploadService photoUploadService)
        {
            _photoService = photoService;
            _photoUploadService = photoUploadService;
        }
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadImage([FromForm]Photo photo,[FromForm]IFormFile file)
        {
            IResult result = await _photoUploadService.UploadImageAsync(file, photo);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}
