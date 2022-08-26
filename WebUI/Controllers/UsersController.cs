using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Security.Hashing;
using Core.Utilities.Results;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IUserAddressService _userAddressService;
        private readonly IUserCreditCardService _userCreditCardService;

        public UsersController(IUserService userService, IRoleService roleService, IUserAddressService userAddressService, IUserCreditCardService userCreditCardService)
        {
            _userService = userService;
            _roleService = roleService;
            _userAddressService = userAddressService;
            _userCreditCardService = userCreditCardService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            IDataResult<List<User>> result = await _userService.GetListAsync();
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            IDataResult<User> result = await _userService.GetByIdAsync(id);
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{userId}/addresses")]
        public async Task<IActionResult> GetAddressesByUserId(int userId)
        {
            IDataResult<List<UserAddressCityDto>> result = await _userAddressService.GetListCityNameByUserIdAsync(userId);
            if (result.IsSuccess == false)
            {
                return Ok(result);
            }
            return Ok(result);
        }

        [HttpGet("{userId}/creditcards")]
        public async Task<IActionResult> GetCardsByUserId(int userId)
        {
            IDataResult<List<CreditCardWithUserDto>> result = await _userCreditCardService.GetUserCreditCardsAsync(userId);
            if (result.IsSuccess == false)
            {
                return Ok(result);
            }
            return Ok(result);
        }

        [HttpGet("{userId}/roles")]
        public async Task<ActionResult> GetUserRoles(int userId)
        {
            IDataResult<User> userResult = await _userService.GetByIdAsync(userId);
            if (userResult.IsSuccess == false)
            {
                return BadRequest(userResult);
            }
            IResult result = await _userService.GetClaimsAsync(userResult.Data);
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
        {
            IDataResult<User> user = await _userService.GetByIdAsync(updateUserDto.UserId);
            User updatedUser = user.Data;
            if (HashingHelper.VerifyPasswordHash(updateUserDto.Password, user.Data.PasswordHash,
                user.Data.PasswordSalt) == false)
            {
                return Ok(new ErrorResult(Messages.WrongPassword));
            }
            user.Data.FirstName = updateUserDto.FirstName;
            user.Data.LastName = updateUserDto.LastName;
            IResult result = await _userService.UpdateAsync(user.Data);
            if (result.IsSuccess == false)
            {
                return Ok(result);
            }
            return Ok(new SuccessResult(Messages.SuccessfulUserUpdate));
        }
        [HttpPut]
        [Route("updateAdmin")]
        public async Task<IActionResult> UpdateUserAdmin(UpdateUserAdminDto updateUserAdminDto)
        {
            IDataResult<User> findUserResult = await _userService.GetByIdAsync(updateUserAdminDto.Id);
            if (findUserResult.IsSuccess == false)
            {
                return BadRequest(findUserResult);
            }
            await AddUserRoleAsync(updateUserAdminDto, findUserResult);
            await RemoveUserRoleAsync(updateUserAdminDto, findUserResult);

            findUserResult.Data.FirstName = updateUserAdminDto.FirstName;
            findUserResult.Data.LastName = updateUserAdminDto.LastName;
            IResult result = await _userService.UpdateAsync(findUserResult.Data);
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
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
            var result = await _userService.ResetPasswordAsync(changePasswordModel);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("sendcode")]
        public async Task<IActionResult> SendCode(SendCodeDto sendCodeDto)
        {
            var result = await _userService.SendCodeAsync(sendCodeDto);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("verifycode")]
        public async Task<IActionResult> VerifyCode(VerifyCodeDto verifyCodeDto)
        {
            var user = await _userService.GetByIdAsync(verifyCodeDto.UserId);
            if (user.IsSuccess == false)
                return BadRequest(user);
            var result = await _userService.VerifyCodeAsync(verifyCodeDto);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
