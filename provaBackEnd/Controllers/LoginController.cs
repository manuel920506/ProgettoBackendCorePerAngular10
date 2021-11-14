using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;

        public LoginController(ILoginService loginService, IConfiguration config)
        {
            _loginService = loginService;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                user.Password = Encrypt.EncryptPassword(user.Password);
                User validateUser = await _loginService.ValidateUser(user);
                if (validateUser == null)
                {
                    return BadRequest(new { message = "User or Password invalid!"});
                }

                string tokenString = JwtConfigurator.GetToken(validateUser, _config);

                return Ok(new { token = tokenString });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
