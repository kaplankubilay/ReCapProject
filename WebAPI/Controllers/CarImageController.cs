using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        private ICarImageService _carImageService;

        public CarImageController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getallcarimages")]
        public IActionResult GetAllCarImages()
        {
            var result = _carImageService.GetAllCarImages();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("updatecarimage")]
        public IActionResult UpdateCarImage([FromForm(Name = ("Image"))] IFormFile file,CarImage carImage)
        {
            var result = _carImageService.UpdateCarImage(file,carImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addcarimage")]
        public IActionResult AddCarImage([FromForm(Name = ("Image"))] IFormFile file,CarImage carImage)
        {
            var result = _carImageService.AddCarImage(file,carImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("deletecarimage")]
        public IActionResult DeleteCarImage(CarImage carImage)
        {
            var result = _carImageService.DeleteCarImage(carImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
