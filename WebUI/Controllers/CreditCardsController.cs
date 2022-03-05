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
    public class CreditCardsController : ControllerBase
    {
        private readonly IUserCreditCardService _userCreditCardService;

        public CreditCardsController(IUserCreditCardService userCreditCardService)
        {
            _userCreditCardService = userCreditCardService;
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetCards()
        {
            var result = _userCreditCardService.GetListAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("getallbyuserid")]
        public IActionResult GetCardsByUserId(int userId)
        {
            var result = _userCreditCardService.GetUserCreditCardsAsync(userId);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetCard(int id)
        {
            var result = await _userCreditCardService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddCard(UserCreditCard userCreditCard)
        {
            var result = await _userCreditCardService.AddAsync(userCreditCard);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var card = await _userCreditCardService.GetByIdAsync(id);
            if (card.Data == null)
            {
                return Ok(new ErrorResult(Messages.CardIsNotFound));
            }
            var result = await _userCreditCardService.DeleteAsync(card.Data);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}
