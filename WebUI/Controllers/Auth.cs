using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Email;
using Core.Utilities.Results;
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
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _userService.GetByMail(userForLoginDto.Email);
            if (user.Data == null)
            {
                return BadRequest("Kullanıcı bulunamadı");
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
                    UserId=user.Data.Id,
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
        
        [HttpPost]
        [Route("sendemail")]
        public async Task<IActionResult> SendEmail(string email)
        {
            var userCheck = await _userService.GetByMail(email);
            if (userCheck.Data == null)
            {
                return BadRequest("Böyle bir kullanıcı bulunamadı");
            }

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
