using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using provaBackEnd.Domain.IServices;
using provaBackEnd.Domain.Models;
using provaBackEnd.DTO;
using provaBackEnd.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace provaBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService; 
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                bool validateExistence = await _userService.ValidateExistence(user);
                if (validateExistence)
                {
                    return BadRequest(new { message = "User " + user.UserNAme + " already exists" });
                }
                user.Password = Encrypt.EncryptPassword(user.Password);
                await _userService.SaveUser(user);
                return Ok(new { message = "Successfully registered user!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //localhost:porta/api/User/ChangePassword
        [Route("ChangePassword")]
        [HttpPut]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePassword)
        {
            try
            {
                int userId = 4;
                string encryptedPassword = Encrypt.EncryptPassword(changePassword.lastPassword);
                User user = await _userService.ValidatePassword(userId, encryptedPassword);
                if (user == null)
                {
                    return BadRequest((new { message = "The password is incorrect" }));
                }
                else 
                {
                    user.Password = Encrypt.EncryptPassword(changePassword.newPassword);
                    await _userService.UpdatePassword(user);
                    return Ok(new { message = "The password has been successfully updated" });
                } 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
