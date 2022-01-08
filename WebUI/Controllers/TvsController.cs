﻿using Business.Abstract;
using Core.Utilities.Helpers;
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
            var result = await _tvService.GetListTvWithPhotos();
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
            var result = await _tvService.GetTvDetail(id);
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
            var result = await _tvService.GetListTvDetailsByCategoryId(id);
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
            var result = await _tvService.GetListTvDetails();
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
            var result = await _tvService.GetListPhotos(tvId);
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
            Thread.Sleep(1);
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
            Thread.Sleep(1);
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
            Thread.Sleep(1);
            var tv = await _tvService.GetById(tvId);
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
