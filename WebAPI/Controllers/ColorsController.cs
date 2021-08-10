using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getallcolors")]
        public IActionResult GetAllColors()
        {
            var result = _colorService.GetAllColors();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycolorId")]
        public IActionResult GetByColorId(int colorId)
        {
            var result = _colorService.GetByIdColor(colorId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("updatecolor")]
        public IActionResult UpdateColor(Color color)
        {
            var result = _colorService.UpdateColor(color);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addcolor")]
        public IActionResult AddColor(Color color)
        {
            var result = _colorService.AddColor(color);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("deletecolor")]
        public IActionResult DeleteColor(Color color)
        {
            var result = _colorService.DeleteColor(color);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
