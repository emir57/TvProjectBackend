using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Security.Hashing;
using Core.Utilities.Email;
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
        private readonly IUserCodeService _userCodeService;
        private readonly IEmailService _emailService;
        public UsersController(IUserService userService, IRoleService roleService, IUserCodeService userCodeService, IEmailService emailService)
        {
            _userService = userService;
            _roleService = roleService;
            _userCodeService = userCodeService;
            _emailService = emailService;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetUsers()
        {
            IDataResult<List<User>> result = await _userService.GetListAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetUserById(int id)
        {
            IDataResult<User> result = await _userService.GetByIdAsync(id);
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
            IDataResult<User> user = await _userService.GetByIdAsync(updateUserDto.UserId);
            User updatedUser = user.Data;
            if (!HashingHelper.VerifyPasswordHash(updateUserDto.Password, user.Data.PasswordHash, user.Data.PasswordSalt))
            {
                return Ok(new ErrorResult(Messages.WrongPassword));
            }
            user.Data.FirstName = updateUserDto.FirstName;
            user.Data.LastName = updateUserDto.LastName;
            IResult result = await _userService.UpdateAsync(user.Data);
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
            IDataResult<User> findUser = await _userService.GetByIdAsync(updateUserAdminDto.Id);
            if (findUser.Data == null)
            {
                return BadRequest(Messages.UserNotFound);
            }
            await AddUserRoleAsync(updateUserAdminDto, findUser);
            await RemoveUserRoleAsync(updateUserAdminDto, findUser);

            findUser.Data.FirstName = updateUserAdminDto.FirstName;
            findUser.Data.LastName = updateUserAdminDto.LastName;
            IResult result = await _userService.UpdateAsync(findUser.Data);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(new SuccessResult(Messages.SuccessfulUserUpdate));
        }

        private async Task RemoveUserRoleAsync(UpdateUserAdminDto updateUserAdminDto, IDataResult<User> findUser)
        {
            if (updateUserAdminDto.RemovedRoles != null)
            {
                foreach (var role in updateUserAdminDto.RemovedRoles)
                {
                    await _roleService.RemoveUserRoleAsync(findUser.Data, role);
                }
            }
        }

        private async Task AddUserRoleAsync(UpdateUserAdminDto updateUserAdminDto, IDataResult<User> findUser)
        {
            if (updateUserAdminDto.AddedRoles != null)
            {
                foreach (var role in updateUserAdminDto.AddedRoles)
                {
                    await _roleService.AddUserRoleAsync(findUser.Data, role);
                }
            }
        }

        [HttpPost]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            IDataResult<User> user = await _userService.GetByIdAsync(changePasswordModel.UserId);
            if (!HashingHelper.VerifyPasswordHash(changePasswordModel.OldPassword, user.Data.PasswordHash, user.Data.PasswordSalt))
            {
                return Ok(new ErrorResult(Messages.WrongPassword));
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(changePasswordModel.NewPassword, out passwordHash, out passwordSalt);
            user.Data.PasswordHash = passwordHash;
            user.Data.PasswordSalt = passwordSalt;
            IResult result = await _userService.UpdateAsync(user.Data);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(new SuccessResult(Messages.SuccessfulChangePassword));
        }
        [HttpPost("sendcode")]
        public async Task<IActionResult> SendCode(int userId)
        {
            string code = new Random().Next(1000, 9999).ToString();
            var user = await _userService.GetByIdAsync(userId);
            if (user.Data == null)
            {
                return BadRequest(user);
            }
            var getUserCode = await _userCodeService.GetByUserIdAysnc(userId);
            if (!getUserCode.IsSuccess)
            {
                await _userCodeService.AddAsync(new Entities.Concrete.UserCode
                {
                    UserId = userId,
                    Code = code
                });
                await SendEmailAsync(user.Data, code);
                return Ok();
            }
            var userCode = getUserCode.Data;
            userCode.Code = code;
            await SendEmailAsync(user.Data, code);
            await _userCodeService.UpdateAsync(userCode);

            return Ok();
        }

        [HttpPost("verifycode")]
        public async Task<IActionResult> VerifyCode(int userId,string code)
        {
            var user = await _userService.GetByIdAsync(userId);
            if (user.Data == null)
            {
                return BadRequest(user);
            }
            var getUserCode = await _userCodeService.GetByUserIdAysnc(userId);
            if (!getUserCode.IsSuccess)
            {
                return BadRequest();
            }
            if(getUserCode.Data.Code == code)
            {
                return Ok();
            }
            return BadRequest();
        }

        private async Task SendEmailAsync(User user, string code)
        {
            await _emailService.SendEmailAsync(user.Email, "Giriş İçin dorğulama kodunuz", code);
        }
    }
}
