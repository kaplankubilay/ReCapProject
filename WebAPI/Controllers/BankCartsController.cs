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
    public class BankCartsController : Controller
    {
        private IBankCartService _bankCartService;

        public BankCartsController(IBankCartService bankCartService)
        {
            _bankCartService = bankCartService;
        }

        [HttpGet("getbankcarts")]
        public IActionResult GetBankCarts(int userId)
        {
            var result = _bankCartService.GetCartByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addbankcard")]
        public IActionResult AddBankCard(BankCart bankCart)
        {
            var result = _bankCartService.AddBankCart(bankCart);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("deletebankcard")]
        public IActionResult DeleteBankCard(BankCart bankCart)
        {
            var result = _bankCartService.DeleteBankCart(bankCart);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
