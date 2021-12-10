using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Security.Hashing;
using Core.Utilities.Email;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IPhotoUploadService _imageService;
        private readonly IEmailService _emailService;
        public Auth(IAuthService authService, IUserService userService, IPhotoUploadService imageService,IEmailService emailService)
        {
            _authService = authService;
            _userService = userService;
            _imageService = imageService;
            _emailService = emailService;
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var checkUser = await _authService.UserExists(userForRegisterDto.Email);
            if (!checkUser.IsSuccess)
            {
                return BadRequest(checkUser.Message);
            }
            var result = await _authService.Register(userForRegisterDto, userForRegisterDto.Password);
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
            var user = await _userService.GetByMail(userForLoginDto.Email);
            if (user.Data == null)
            {
                return BadRequest(new ErrorResult("Böyle bir kullanıcı yok"));
            }
            var result = await _authService.Login(userForLoginDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            var token = await _authService.CreateAccessToken(user.Data);
            var loginingUser = new LoginDto
            {
                AccessToken = token.Data,
                User = new LoginingUser
                {
                    Email=user.Data.Email,
                    Id=user.Data.Id,
                    FirstName=user.Data.FirstName,
                    LastName=user.Data.LastName
                }
            };
            return Ok(new SuccessDataResult<LoginDto>(loginingUser,result.Message));
        }
        [HttpPost]
        [Route("checkuser")]
        public async Task<ActionResult> Login(User user)
        {
            var checkUser = await _userService.GetByMail(user.Email);
            if (checkUser.Data != null)
            {
                return Ok(new SuccessResult());
            }
            return BadRequest(new ErrorResult());
        }
        [HttpGet]
        [Route("getuser")]
        public async Task<ActionResult> Login(int id)
        {
            var user = await _userService.Get(x => x.Id == id);
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
            var userCheck = await _userService.GetByMail(email.Email);
            if (userCheck.Data == null)
            {
                return BadRequest(new ErrorResult("Böyle bir kullanıcı bulunamadı"));
            }
            string key = Guid.NewGuid()+"";
            userCheck.Data.Key = key;
            await _userService.Update(userCheck.Data);
            await _emailService.SendEmailAsync(email.Email, "Şifre Sıfırlama", $"<a href='http://localhost:4200/resetpassword/{key}'>Şifreni Sıfırlamak İçin Tıkla</a>");
            return Ok(new SuccessResult("Şifre Sıfırlama isteği Başarıyla gönderildi"));
        }
        [HttpPost]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            byte[] passwordHash, passwordSalt;
            var getUser = await _userService.Get(x => x.Key == resetPasswordModel.Key);
            if (getUser.Data == null)
            {
                return BadRequest("Geçersiz Key");
            }
            if (getUser.Data.Key != resetPasswordModel.Key)
            {
                return BadRequest("Geçersiz Key");
            }
            if (!HashingHelper.VerifyPasswordHash(resetPasswordModel.OldPassword, getUser.Data.PasswordHash, getUser.Data.PasswordSalt))
            {
                return BadRequest("Eski Şifreniz Uyuşmuyor");
            }
            HashingHelper.CreatePasswordHash(resetPasswordModel.NewPassword, out passwordHash, out passwordSalt);
            getUser.Data.PasswordHash = passwordHash;
            getUser.Data.PasswordSalt = passwordSalt;
            getUser.Data.Key = "";
            await _userService.Update(getUser.Data);
            return Ok(new SuccessResult("Şifreniz Başarıyla Sıfırlandı"));

        }
        [HttpGet]
        [Route("getroles")]
        public async Task<IActionResult> GetUserRoles(int id)
        {
            var user = await _userService.Get(x => x.Id == id);
            if (user.Data == null)
            {
                return BadRequest(new ErrorDataResult<User>("Kullanıcı Bulunamadı"));
            }
            var roles = await _userService.GetClaims(user.Data);
            return Ok(roles);
        }

        [HttpPost]
        [Route("uploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile image)
        {
            var result = await _imageService.UploadImageAsync(image);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        
    }
}
