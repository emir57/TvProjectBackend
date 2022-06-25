using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            IDataResult<List<City>> result = await _cityService.GetListAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            IDataResult<City> result = await _cityService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddCity(City city)
        {
            IResult result = await _cityService.AddAsync(city);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCity(City city)
        {
            IResult result = await _cityService.UpdateAsync(city);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("{cityId}")]
        public async Task<IActionResult> DeleteCity(int cityId)
        {
            IDataResult<City> city = await _cityService.GetByIdAsync(cityId);
            if (city.Data == null)
            {
                return BadRequest(Messages.CityIsNotFound);
            }
            IResult result = await _cityService.UpdateAsync(city.Data);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
