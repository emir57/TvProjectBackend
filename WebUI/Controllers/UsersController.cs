﻿using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Security.Hashing;
using Core.Utilities.Results;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetAll();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
        {
            var user = await _userService.Get(x => x.Id == updateUserDto.UserId);
            if (!HashingHelper.VerifyPasswordHash(updateUserDto.Password, user.Data.PasswordHash, user.Data.PasswordSalt))
            {
                return Ok(new ErrorResult(Messages.WrongPassword));
            }
            user.Data.FirstName = updateUserDto.FirstName;
            user.Data.LastName = updateUserDto.LastName;
            var result = await _userService.Update(user.Data);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(new SuccessResult(Messages.SuccessfulUserUpdate));
        }
        [HttpPost]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var user = await _userService.Get(x => x.Id == changePasswordModel.UserId);
            if (!HashingHelper.VerifyPasswordHash(changePasswordModel.OldPassword, user.Data.PasswordHash, user.Data.PasswordSalt))
            {
                return Ok(new ErrorResult(Messages.WrongPassword));
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(changePasswordModel.NewPassword, out passwordHash, out passwordSalt);
            user.Data.PasswordHash = passwordHash;
            user.Data.PasswordSalt = passwordSalt;
            var result = await _userService.Update(user.Data);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(new SuccessResult(Messages.SuccessfulChangePassword));
        }
    }
}