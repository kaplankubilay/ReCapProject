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
    public class FuelsController : ControllerBase
    {
        private IFuelService _fuelService;

        public FuelsController(IFuelService fuelService)
        {
            _fuelService = fuelService;
        }

        [HttpGet("getallfuels")]
        public IActionResult GetAllFuels()
        {
            var result = _fuelService.GetAAllFuels();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyfuelId")]
        public IActionResult GetByFuelId(int fuelId)
        {
            var result = _fuelService.GetByIdFuel(fuelId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("updatefuel")]
        public IActionResult UpdateFuel(Fuel fuel)
        {
            var result = _fuelService.UpdateFuel(fuel);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addfuel")]
        public IActionResult AddFuel(Fuel fuel)
        {
            var result = _fuelService.AddFuel(fuel);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("deletefuel")]
        public IActionResult DeleteFuel(Fuel fuel)
        {
            var result = _fuelService.DeleteFuel(fuel);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
