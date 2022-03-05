using Business.Abstract;
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
    public class TvBrandsController : ControllerBase
    {
        private readonly ITvBrandService _brandService;
        public TvBrandsController(ITvBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        [Route("getall")]
        public ActionResult GetTvBrands()
        {
            var result = _brandService.GetList();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddTvBrand(TvBrand tvBrand)
        {
            Thread.Sleep(5);
            var result = await _brandService.AddAsync(tvBrand);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateTvBrand(TvBrand tvBrand)
        {
            Thread.Sleep(1);
            var result = await _brandService.UpdateAsync(tvBrand);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteTvBrand(int tvBrandId)
        {
            Thread.Sleep(1);
            var tvBrand = await _brandService.GetByIdAsync(tvBrandId);
            if (tvBrand.Data == null)
            {
                return BadRequest("Silinecek ürün bulunamadı");
            }
            var result = await _brandService.DeleteAsync(tvBrand.Data);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
