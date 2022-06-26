using Business.Abstract;
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
            IDataResult<List<TvBrand>> result = await _brandService.GetListAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("getallwithcount")]
        public async Task<ActionResult> GetTvBrandsWithCount()
        {
            IDataResult<List<CategoryWithCountDto>> result = await _brandService.GetBrandsWithCountAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("getallwithpriceaverage")]
        public async Task<ActionResult> GetTvBrandsWithPriceAverage()
        {
            IDataResult<List<CategoryWithPriceAverageDto>> result = await _brandService.GetBrandsWithPriceAverageAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetTvBrandsById(int id)
        {
            IDataResult<TvBrand> result = await _brandService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> AddTvBrand(TvBrand tvBrand)
        {
            IResult result = await _brandService.AddAsync(tvBrand);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateTvBrand(TvBrand tvBrand)
        {
            IResult result = await _brandService.UpdateAsync(tvBrand);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteTvBrand(int tvBrandId)
        {
            IDataResult<TvBrand> tvBrand = await _brandService.GetByIdAsync(tvBrandId);
            if (tvBrand.Data == null)
            {
                return BadRequest("Silinecek ürün bulunamadı");
            }
            IResult result = await _brandService.DeleteAsync(tvBrand.Data);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
