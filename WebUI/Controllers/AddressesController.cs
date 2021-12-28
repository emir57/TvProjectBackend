using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public CreditCardsController(IUserCreditCardService userCreditCardService)
        {
            _userCreditCardService = userCreditCardService;
        }
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAddressesByUserId(int userId)
        {
            var result = await _userCreditCardService.GetAll(x => x.UserId == userId);
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
            var result = await _userCreditCardService.Get(x => x.Id == id);
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
            var address = await _userCreditCardService.Get(x => x.Id == id);
            if (address.Data == null)
            {
                return Ok(new ErrorResult(Messages.AddressIsNotFound));
            }
            var result = await _userCreditCardService.Delete(address.Data);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}
