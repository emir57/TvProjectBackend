﻿using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<ActionResult> GetRoles()
        {
            IDataResult<List<Role>> result = await _roleService.GetListAsync();
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            IDataResult<Role> result = await _roleService.GetByIdAsync(id);
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddRole(Role role)
        {
            IResult result = await _roleService.AddAsync(role);
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateRole(Role role)
        {
            IResult result = await _roleService.UpdateAsync(role);
            if (result.IsSuccess == false)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpDelete("{roleId}")]
        public async Task<ActionResult> DeleteRole(int roleId)
        {
            IDataResult<Role> roleResult = await _roleService.GetByIdAsync(roleId);
            if (roleResult.IsSuccess == false)
            {
                return BadRequest(roleResult);
            }
            IResult result = await _roleService.DeleteAsync(roleResult.Data);
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
