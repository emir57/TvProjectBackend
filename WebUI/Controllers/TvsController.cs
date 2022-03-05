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
        public ActionResult GetTvs()
        {
            var result = _tvService.GetListTvWithPhotos();
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
            var result = await _tvService.GetTvDetailAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("getbycategoryid")]
        public ActionResult GetTvsByCategoryId(int id, int page = 1)
        {
            var result = _tvService.GetListTvDetailsByCategoryId(id);
            //if (page != -1)
            //{
            //    result = GetProductsPage(page, result);
            //}
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        private static IDataResult<List<TvAndPhotoDetailDto>> GetProductsPage(int page, IDataResult<List<TvAndPhotoDetailDto>> result)
        {
            var totalPage = Math.Ceiling((decimal)result.Data.Count / 6);
            var newResult = new SuccessDataResult<List<TvAndPhotoDetailDto>>
                (result.Data.Skip(page-1 * 6).Take(6).ToList(), result.Message, (int)totalPage);
            return newResult;
        }

        [HttpGet]
        [Route("gettvdetail")]
        public ActionResult GetTvDetails(int tvId,int page=1)
        {
            var result = _tvService.GetListTvDetails();
            //if (page != -1)
            //{
            //    var totalPage = Math.Ceiling((decimal)result.Data.Count / 6);
            //    var newResult = new SuccessDataResult<List<TvAndPhotoDetailDto>>
            //        (result.Data.Skip(page - 1 * 6).Take(6).ToList(), result.Message, (int)totalPage);
            //    return Ok(newResult);
            //}
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("gettvphotos")]
        public ActionResult GetTvPhotos(int tvId)
        {
            var result = _tvService.GetListPhotos(tvId);
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
            var result = await _tvService.AddAsync(tv);
            
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
            var result = await _tvService.UpdateAsync(tv);
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
            var tv = await _tvService.GetByIdAsync(tvId);
            if (tv.Data == null)
            {
                return BadRequest("Silinecek ürün bulunamadı");
            }
            var result = await _tvService.DeleteAsync(tv.Data);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
