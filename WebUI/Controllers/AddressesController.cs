﻿using Business.Abstract;
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
    public class AddressesController : ControllerBase
    {
        private readonly IUserAddressService _userAddressService;

        public AddressesController(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAddressesByUserId(int userId)
        {
            var result = await _userAddressService.GetListCityNameByUserIdAsync(userId);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetAddress(int id)
        {
            var result = await _userAddressService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = (await _userAddressService.GetByIdAsync(id)).Data;
            if (address == null)
            {
                return Ok(new ErrorResult(Messages.AddressIsNotFound));
            }
            address.DeletedDate = DateTime.Now;
            var result = await _userAddressService.UpdateAsync(address);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAddress(UserAddress userAddress)
        {
            var result = await _userAddressService.AddAsync(userAddress);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAddress(UserAddress userAddress)
        {
            var result = await _userAddressService.UpdateAsync(userAddress);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}
