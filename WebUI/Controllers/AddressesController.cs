using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
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
    public class AddressesController : ControllerBase
    {
        private readonly IUserAddressService _userAddressService;

        public AddressesController(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }
        [HttpGet("getbyuserid")]
        public async Task<IActionResult> GetAddressesByUserId(int userId)
        {
            IDataResult<List<UserAddressCityDto>> result = await _userAddressService.GetListCityNameByUserIdAsync(userId);
            if (result.IsSuccess == false)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(int id)
        {
            IDataResult<UserAddress> result = await _userAddressService.GetByIdAsync(id);
            if (result.IsSuccess == false)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            UserAddress address = (await _userAddressService.GetByIdAsync(id)).Data;
            if (address == null)
            {
                return Ok(new ErrorResult(Messages.AddressIsNotFound));
            }
            address.DeletedDate = DateTime.Now;
            IResult result = await _userAddressService.UpdateAsync(address);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddAddress(UserAddress userAddress)
        {
            IResult result = await _userAddressService.AddAsync(userAddress);
            if (result.IsSuccess == false)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UserAddress userAddress)
        {
            IResult result = await _userAddressService.UpdateAsync(userAddress);
            if (result.IsSuccess == false)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}
