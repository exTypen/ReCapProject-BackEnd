using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCreditCardsController : ControllerBase
    {
        IUserCreditCardService _userCreditCardService;

        public UserCreditCardsController(IUserCreditCardService userCreditCardService)
        {
            _userCreditCardService = userCreditCardService;
        }

        [HttpPost("add")]
        public IActionResult Add(UserCreditCard userCreditCard)
        {
            var result = _userCreditCardService.Add(userCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserCreditCard userCreditCard)
        {
            var result = _userCreditCardService.Delete(userCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
