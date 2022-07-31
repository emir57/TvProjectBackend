using Business.Abstract;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvsController : ControllerBase
    {
        private readonly ITvService _tvService;
        private readonly IPhotoUploadService _imageUploadService;
        private readonly IPhotoService _photoService;
        private readonly ICacheManager _cacheManager;
        public TvsController(ITvService tvService, IPhotoUploadService imageUploadService, IPhotoService photoService)
        {
            _tvService = tvService;
            _imageUploadService = imageUploadService;
            _photoService = photoService;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            TvAndPhotoDto dto = new TvAndPhotoDto
            {
                BrandId = 1,
                Discount = 5,
                ScreenInch = "32"
            };
            if (_cacheManager.IsAdd("test"))
            {
                return Ok(_cacheManager.Get<TvAndPhotoDto>("test"));
            }
            _cacheManager.Add("test", dto, 5);
            return BadRequest(dto);

        }
        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult> GetTvs()
        {
            IDataResult<List<TvAndPhotoDto>> result;
            if (_cacheManager.IsAdd("test2"))
            {
                result = _cacheManager.Get<SuccessDataResult<List<TvAndPhotoDto>>>("test2");
            }
            else
            {
                result = await _tvService.GetListTvWithPhotosAsync();
                if (result.IsSuccess)
                    _cacheManager.Add("test2", result, 5);
            }
            if (result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet("removecache")]
        public IActionResult RemoveCache()
        {
            _cacheManager.RemoveByPattern("test2");
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTv(int id)
        {
            IDataResult<TvAndPhotoDetailDto> result = await _tvService.GetTvDetailAsync(id);
            if (result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet("getbycategoryid")]
        public async Task<ActionResult> GetTvsByCategoryId(int id)
        {
            IDataResult<List<TvAndPhotoDetailDto>> result = await _tvService.GetListTvDetailsByCategoryIdAsync(id);
            if (result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet("gettvdetail")]
        public async Task<ActionResult> GetTvDetails(int tvId)
        {
            IDataResult<List<TvAndPhotoDetailDto>> result = await _tvService.GetListTvDetailsAsync();
            if (result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet("gettvphotos")]
        public async Task<ActionResult> GetTvPhotos(int tvId)
        {
            IDataResult<List<Photo>> result = await _tvService.GetListPhotosAsync(tvId);
            if (result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddTv([FromBody] Tv tv, [FromForm] IFormFile photo)
        {
            IResult result = await _tvService.AddAsync(tv);
            if (result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateTv([FromBody] Tv tv)
        {
            IResult result = await _tvService.UpdateAsync(tv);
            if (result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpDelete("{tvId}")]
        public async Task<ActionResult> DeleteTv(int tvId)
        {
            IDataResult<Tv> tvResult = await _tvService.GetByIdAsync(tvId);
            if (tvResult.IsSuccess == false)
            {
                return BadRequest(tvResult);
            }
            IResult result = await _tvService.DeleteAsync(tvResult.Data);
            if (result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
