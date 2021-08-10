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
    public class RentalsController : ControllerBase
    {
        private IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getallrentals")]
        public IActionResult GetAllRentals()
        {
            var result = _rentalService.GetAllRentals();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyrentalId")]
        public IActionResult GetByRentalId(int rentalId)
        {
            var result = _rentalService.GetByRentalId(rentalId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getrentaldetaildto")]
        public IActionResult GetRentalDetailDto()
        {
            var result = _rentalService.GetRentalDetailDto();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("updaterental")]
        public IActionResult UpdateFuel(Rental rental)
        {
            var result = _rentalService.UpdateRental(rental);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addrental")]
        public IActionResult AddFuel(Rental rental)
        {
            var result = _rentalService.AddRental(rental);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("deleterental")]
        public IActionResult DeleteRental(Rental rental)
        {
            var result = _rentalService.DeleteRental(rental);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
