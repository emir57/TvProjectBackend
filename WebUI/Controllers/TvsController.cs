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
        public TvsController(ITvService tvService)
        {
            _tvService = tvService;
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
        [Route("getbycategoryid")]
        public async Task<ActionResult> GetTvsByCategoryId(int id)
        {
            var result = await _tvService.GetTvWithPhotos(t => t.BrandId == id);
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
            var result = await _tvService.GetTvDetails(tvId);
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
        public async Task<ActionResult> AddTv(Tv tv)
        {
            var result = await _tvService.Add(tv);
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
