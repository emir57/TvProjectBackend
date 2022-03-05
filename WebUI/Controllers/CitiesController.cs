using Business.Abstract;
using Business.Constants;
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
        [Route("getall")]
        public IActionResult GetCities()
        {
            var result = _cityService.GetList();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("getbyId")]
        public async Task<IActionResult> GetCity(int id)
        {
            var result = await _cityService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddCity(City city)
        {
            var result = await _cityService.AddAsync(city);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateCity(City city)
        {
            var result = await _cityService.UpdateAsync(city);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteCity(int cityId)
        {
            var city = await _cityService.GetByIdAsync(cityId);
            if (city.Data == null)
            {
                return BadRequest(Messages.CityIsNotFound);
            }
            var result = await _cityService.UpdateAsync(city.Data);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
