using System;
using ManageUsers.API.Interfaces;
using ManageUsers.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManageUsers.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;

        public AuthenticationController(
            IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            var user = _authenticateService.Authenticate(model.UserName, model.Password);

            if (user is null) return BadRequest(new { message = "Username or Password is incorrect" });

            return Ok(user);
        }
    }
}