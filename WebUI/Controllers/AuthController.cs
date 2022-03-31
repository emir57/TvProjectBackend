using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Security.Hashing;
using Core.Security.JWT;
using Core.Utilities.Email;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IPhotoUploadService _imageService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        public AuthController(IAuthService authService, IUserService userService, IPhotoUploadService imageService, IEmailService emailService, IMapper mapper)
        {
            _authService = authService;
            _userService = userService;
            _imageService = imageService;
            _emailService = emailService;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            IResult checkUser = await _authService.UserExistsAsync(userForRegisterDto.Email);
            if (!checkUser.IsSuccess)
            {
                return BadRequest(checkUser.Message);
            }
            IDataResult<User> result = await _authService.RegisterAsync(userForRegisterDto, userForRegisterDto.Password);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(UserForLoginDto userForLoginDto)
        {
            IDataResult<User> result = await _authService.LoginAsync(userForLoginDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            IDataResult<AccessToken> token = await _authService.CreateAccessTokenAsync(result.Data);
            LoginDto loginingUser = new LoginDto
            {
                AccessToken = token.Data,
                User = _mapper.Map<LoginingUser>(result.Data)
            };
            return Ok(new SuccessDataResult<LoginDto>(loginingUser,result.Message));
        }
        [HttpPost]
        [Route("checkuser")]
        public async Task<ActionResult> CheckUser(User user)
        {
            IDataResult<User> checkUser = await _userService.GetByMailAsync(user.Email);
            if (checkUser.Data != null)
            {
                return Ok(new SuccessResult());
            }
            return BadRequest(new ErrorResult());
        }
        [HttpGet]
        [Route("getuser")]
        public async Task<ActionResult> GetUser(int id)
        {
            IDataResult<User> user = await _userService.GetByIdAsync(id);
            if (user.Data != null)
            {
                return Ok(new SuccessDataResult<User>(user.Data));
            }
            return BadRequest(new ErrorResult());
        }

        [HttpPost]
        [Route("sendemail")]
        public async Task<IActionResult> SendEmail(SendMailModel email)
        {
            IDataResult<User> userCheck = await _userService.GetByMailAsync(email.Email);
            if (userCheck.Data == null)
            {
                return BadRequest(new ErrorResult(ControllerMessages.UserNotFound));
            }
            string key = Guid.NewGuid()+"";
            userCheck.Data.Key = key;
            await _userService.UpdateAsync(userCheck.Data);
            await _emailService.SendEmailAsync(email.Email, "Şifre Sıfırlama", $"<a href='http://localhost:4200/resetpassword/{key}'>Şifreni Sıfırlamak İçin Tıkla</a>");
            return Ok(new SuccessResult(ControllerMessages.SuccessResetPasswordSendMail));
        }
        [HttpPost]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            byte[] passwordHash, passwordSalt;
            IDataResult<User> getUser = await _userService.GetByKeyAsync(resetPasswordModel.Key);
            if (getUser.Data == null || getUser.Data.Key != resetPasswordModel.Key)
            {
                return BadRequest(ControllerMessages.InvalidKey);
            }
            if (!HashingHelper.VerifyPasswordHash(resetPasswordModel.OldPassword, getUser.Data.PasswordHash, getUser.Data.PasswordSalt))
            {
                return BadRequest(ControllerMessages.WrongOldPassword);
            }
            HashingHelper.CreatePasswordHash(resetPasswordModel.NewPassword, out passwordHash, out passwordSalt);
            getUser.Data.PasswordHash = passwordHash;
            getUser.Data.PasswordSalt = passwordSalt;
            getUser.Data.Key = "";
            await _userService.UpdateAsync(getUser.Data);
            return Ok(new SuccessResult(ControllerMessages.SuccessResetPassword));

        }
        [HttpGet]
        [Route("getroles")]
        public async Task<IActionResult> GetUserRoles(int id)
        {
            IDataResult<User> user = await _userService.GetByIdAsync(id);
            if (user.Data == null)
            {
                return BadRequest(new ErrorDataResult<User>(ControllerMessages.UserNotFound));
            }
            IDataResult<List<Role>> roles = await _userService.GetClaimsAsync(user.Data);
            return Ok(roles);
        }

        //[HttpPost]
        //[Route("uploadImage")]
        //public async Task<IActionResult> UploadImage([FromForm] IFormFile image)
        //{
        //    //var result = await _imageService.UploadImageAsync(image);
        //    //if (!result.IsSuccess)
        //    //{
        //    //    return BadRequest(result.Message);
        //    //}
        //    //return Ok(result.Message);
        //    return Ok();
        //}
        
    }
}
