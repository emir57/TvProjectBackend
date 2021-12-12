using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvsController : ControllerBase
    {
        private readonly ITvService _tvService;
        private readonly IPhotoUploadService _imageUploadService;
        private readonly IPhotoService _photoService;
        public TvsController(ITvService tvService, IPhotoUploadService imageUploadService, IPhotoService photoService)
        {
            _tvService = tvService;
            _imageUploadService = imageUploadService;
            _photoService = photoService;
        }
        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult> GetTvs()
        {
            var result = await _tvService.GetTvWithPhotos();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult> GetTv(int id)
        {
            var result = await _tvService.GetTvDetail(x => x.Id == id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("getbycategoryid")]
        public async Task<ActionResult> GetTvsByCategoryId(int id)
        {
            var result = await _tvService.GetTvDetails(t => t.BrandId == id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("gettvdetail")]
        public async Task<ActionResult> GetTvDetails(int tvId)
        {
            var result = await _tvService.GetTvDetails();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("gettvphotos")]
        public async Task<ActionResult> GetTvPhotos(int tvId)
        {
            var result = await _tvService.GetPhotos(tvId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddTv(Tv tv,[FromForm]IFormFile photo)
        {
            var result = await _tvService.Add(tv);
            var imageResult = await _imageUploadService.UploadImageAsync(photo,tv.Id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateTv(Tv tv)
        {
            var result = await _tvService.Update(tv);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteTv(int tvId)
        {
            var tv = await _tvService.Get(t => t.Id == tvId);
            if (tv.Data == null)
            {
                return BadRequest("Silinecek ürün bulunamadı");
            }
            var result = await _tvService.Delete(tv.Data);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
