using Business.Abstract;
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
    public class TvsController : ControllerBase
    {
        private readonly ITvService _tvService;
        public TvsController(ITvService tvService)
        {
            _tvService = tvService;
        }
        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult> GetTvs()
        {
            var result = await _tvService.GetAll();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("gettvphotos")]
        public async Task<ActionResult> GetTvPhotos(int tvId)
        {
            var result = await _tvService.GetPhotos(tvId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
