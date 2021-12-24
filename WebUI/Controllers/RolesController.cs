using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
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
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        public RolesController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }
        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult> GetRoles()
        {
            var result = await _roleService.GetAll();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("getuserroles")]
        public async Task<ActionResult> GetUserRoles(int userId)
        {
            var user = await _userService.Get(x => x.Id == userId);
            if (user.Data == null)
            {
                return BadRequest(new ErrorResult(Messages.UserNotFound));
            }
            var result = await _userService.GetClaims(user.Data);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddRole(Role role)
        {
            var result = await _roleService.Add(role);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateRole(Role role)
        {
            var result = await _roleService.Update(role);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteRole(int roleId)
        {
            var role = await _roleService.Get(x => x.Id == roleId);
            if (role.Data == null)
            {
                return BadRequest(new ErrorResult(Messages.RoleNotFound));
            }
            var result = await _roleService.Delete(role.Data);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
