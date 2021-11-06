using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using provaBackEnd.Domain.IServices;
using provaBackEnd.Domain.Models;
using provaBackEnd.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace provaBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                user.Password = Encrypt.EncryptPassword(user.Password);
                User validateExistence = await _loginService.ValidateUser(user);
                if (validateExistence == null)
                {
                    return BadRequest(new { message = "User or Password invalid!"});
                } 

                return Ok(new { message = "User " + user.UserNAme });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
