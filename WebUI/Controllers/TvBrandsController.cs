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
    public class TvBrandsController : ControllerBase
    {
        private readonly ITvBrandService _brandService;
        public TvBrandsController(ITvBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult> GetTvBrands()
        {
            var result = await _brandService.GetAll();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddTv(TvBrand tvBrand)
        {
            var result = await _brandService.Add(tvBrand);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateTv(TvBrand tvBrand)
        {
            var result = await _brandService.Update(tvBrand);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteTv(int tvBrandId)
        {
            var tvBrand = await _brandService.Get(t => t.Id == tvBrandId);
            if (tvBrand.Data == null)
            {
                return BadRequest("Silinecek ürün bulunamadı");
            }
            var result = await _brandService.Delete(tvBrand.Data);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
