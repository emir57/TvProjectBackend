using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Security.JWT;
using Core.Utilities.Email;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Controllers;
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        public AuthController(IAuthService authService, IUserService userService, IEmailService emailService, IMapper mapper)
        {
            _authService = authService;
            _userService = userService;
            _emailService = emailService;
            _mapper = mapper;
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            IResult checkUser = await _authService.UserExistsAsync(userForRegisterDto.Email);
            if (checkUser.IsSuccess == false)
                return BadRequest(checkUser.Message);

            IDataResult<User> result = await _authService.RegisterAsync(userForRegisterDto, userForRegisterDto.Password);
            if (result.IsSuccess == false)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(UserForLoginDto userForLoginDto)
        {
            IDataResult<User> result = await _authService.LoginAsync(userForLoginDto);
            if (result.IsSuccess == false)
                return BadRequest(result);


            IDataResult<AccessToken> tokenResult = await _authService.CreateAccessTokenAsync(result.Data);
            LoginDto loginingUser = new LoginDto
            {
                AccessToken = tokenResult.Data,
                User = _mapper.Map<LoginingUserDto>(result.Data)
            };
            return Ok(new SuccessDataResult<LoginDto>(loginingUser, result.Message));
        }

        [HttpPost("checkuser")]
        public async Task<ActionResult> CheckUser(User user)
        {
            IDataResult<User> checkUser = await _userService.GetByMailAsync(user.Email);
            if (checkUser.Data == null)
                return BadRequest(new ErrorResult());

            return Ok(new SuccessResult());
        }
        [HttpGet("getuser")]
        public async Task<ActionResult> GetUser(int id)
        {
            IDataResult<User> user = await _userService.GetByIdAsync(id);
            if (user.Data == null)
                return BadRequest(new ErrorResult());

            return Ok(new SuccessDataResult<User>(user.Data));
        }

        [HttpPost("sendemail")]
        public async Task<IActionResult> SendEmail(SendMailModel email)
        {
            IDataResult<User> userCheck = await _userService.GetByMailAsync(email.Email);
            if (userCheck.Data == null)
                return BadRequest(new ErrorResult(ControllerMessages.UserNotFound));

            string key = Guid.NewGuid().ToString();
            userCheck.Data.Key = key;

            await _userService.UpdateAsync(userCheck.Data);
            await _emailService.SendEmailAsync(email.Email, "Şifre Sıfırlama", $"<a href='http://localhost:4200/resetpassword/{key}'>Şifreni Sıfırlamak İçin Tıkla</a>");

            return Ok(new SuccessResult(ControllerMessages.SuccessResetPasswordSendMail));
        }
        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            IResult result = await _authService.ResetPasswordAsync(resetPasswordModel);
            if (result.IsSuccess == false)
                return BadRequest(result);

            return Ok(result);

        }
        [HttpGet("getroles")]
        public async Task<IActionResult> GetUserRoles(int id)
        {
            IDataResult<User> user = await _userService.GetByIdAsync(id);
            if (user.Data == null)
                return BadRequest(new ErrorDataResult<User>(ControllerMessages.UserNotFound));

            IDataResult<List<Role>> roles = await _userService.GetClaimsAsync(user.Data);
            return Ok(roles);
        }
    }
}
