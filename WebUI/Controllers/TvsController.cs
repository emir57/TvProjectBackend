using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
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
            IDataResult<List<TvAndPhotoDto>> result = await _tvService.GetListTvWithPhotosAsync();
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
            IDataResult<TvAndPhotoDetailDto> result = await _tvService.GetTvDetailAsync(id);
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
            IDataResult<List<TvAndPhotoDetailDto>> result = await _tvService.GetListTvDetailsByCategoryIdAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        private static IDataResult<List<TvAndPhotoDetailDto>> GetProductsPage(int page, IDataResult<List<TvAndPhotoDetailDto>> result)
        {
            decimal totalPage = Math.Ceiling((decimal)result.Data.Count / 6);
            var newResult = new SuccessDataResult<List<TvAndPhotoDetailDto>>
                (result.Data.Skip(page-1 * 6).Take(6).ToList(), result.Message, (int)totalPage);
            return newResult;
        }

        [HttpGet]
        [Route("gettvdetail")]
        public async Task<ActionResult> GetTvDetails(int tvId)
        {
            IDataResult<List<TvAndPhotoDetailDto>> result = await _tvService.GetListTvDetailsAsync();
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
            IDataResult<List<Photo>> result = await _tvService.GetListPhotosAsync(tvId);
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
            IResult result = await _tvService.AddAsync(tv);
            
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
            IResult result = await _tvService.UpdateAsync(tv);
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
            IDataResult<Tv> tv = await _tvService.GetByIdAsync(tvId);
            if (tv.Data == null)
            {
                return BadRequest("Silinecek ürün bulunamadı");
            }
            IResult result = await _tvService.DeleteAsync(tv.Data);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
