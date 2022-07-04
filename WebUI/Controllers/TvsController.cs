﻿using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            if (result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
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
