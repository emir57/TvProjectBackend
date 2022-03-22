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
        private readonly IRoleService _roleService;

        public UsersController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetListAsync();
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
            var user = await _userService.GetByIdAsync(updateUserDto.UserId);
            var updatedUser = user.Data;
            if (!HashingHelper.VerifyPasswordHash(updateUserDto.Password, user.Data.PasswordHash, user.Data.PasswordSalt))
            {
                return Ok(new ErrorResult(Messages.WrongPassword));
            }
            user.Data.FirstName = updateUserDto.FirstName;
            user.Data.LastName = updateUserDto.LastName;
            var result = await _userService.UpdateAsync(user.Data);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(new SuccessResult(Messages.SuccessfulUserUpdate));
        }
        [HttpPost]
        [Route("updateAdmin")]
        public async Task<IActionResult> UpdateUserAdmin(UpdateUserAdminDto updateUserAdminDto)
        {
            var findUser = await _userService.GetByIdAsync(updateUserAdminDto.UserId);
            if(findUser.Data == null)
            {
                return BadRequest(Messages.UserNotFound);
            }
            if (updateUserAdminDto.AddedRoles.Count > 0)
            {
                foreach (var role in updateUserAdminDto.AddedRoles)
                {
                    await _roleService.AddUserRoleAsync(findUser.Data, role);
                }
            }
            if(updateUserAdminDto.RemovedRoles.Count > 0)
            {
                foreach (var role in updateUserAdminDto.RemovedRoles)
                {
                    await _roleService.RemoveUserRoleAsync(findUser.Data, role);
                }
            }
            findUser.Data.FirstName = updateUserAdminDto.FirstName;
            findUser.Data.LastName = updateUserAdminDto.LastName;
            var result = await _userService.UpdateAsync(findUser.Data);
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
            var user = await _userService.GetByIdAsync(changePasswordModel.UserId);
            if (!HashingHelper.VerifyPasswordHash(changePasswordModel.OldPassword, user.Data.PasswordHash, user.Data.PasswordSalt))
            {
                return Ok(new ErrorResult(Messages.WrongPassword));
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(changePasswordModel.NewPassword, out passwordHash, out passwordSalt);
            user.Data.PasswordHash = passwordHash;
            user.Data.PasswordSalt = passwordSalt;
            var result = await _userService.UpdateAsync(user.Data);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(new SuccessResult(Messages.SuccessfulChangePassword));
        }
    }
}
