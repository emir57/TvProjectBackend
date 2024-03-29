﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IActionResult> GetCards()
        {
            IDataResult<List<UserCreditCard>> result = await _userCreditCardService.GetListAsync();
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCard(int id)
        {
            IDataResult<UserCreditCard> result = await _userCreditCardService.GetByIdAsync(id);
            if (result.IsSuccess == false)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddCard(UserCreditCard userCreditCard)
        {
            IResult result = await _userCreditCardService.AddAsync(userCreditCard);
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            IDataResult<UserCreditCard> card = await _userCreditCardService.GetByIdAsync(id);
            if (card.Data == null)
            {
                return Ok(new ErrorResult(Messages.CardIsNotFound));
            }
            IResult result = await _userCreditCardService.DeleteAsync(card.Data);
            if (result.IsSuccess == false)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}
