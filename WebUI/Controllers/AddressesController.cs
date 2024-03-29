﻿using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var addressResult = await _userAddressService.GetByIdAsync(id);
            if (addressResult.IsSuccess == false)
            {
                return BadRequest(addressResult);
            }
            addressResult.Data.DeletedDate = DateTime.Now;
            IResult result = await _userAddressService.UpdateAsync(addressResult.Data);
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
