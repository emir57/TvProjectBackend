﻿using Business.Abstract;
using Core.Entities.Dtos;
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
        public Auth(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
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
                return BadRequest(result.Message);
            }
            var token = await _authService.CreateAccessToken(user.Data);
            return Ok(token);
        }
        [HttpPost]
        [Route("uploadImage")]
        public async Task<IActionResult> UploadImage([FromForm]IFormFile image)
        {
            if (!(image.Length > 0))
            {
                return BadRequest("Lütfen resmi yükleyiniz.");
            }
            var ex = Path.GetExtension(image.FileName);
            var name = Guid.NewGuid() + ex;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Images/" + name);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            return Ok();
        }
    }
}