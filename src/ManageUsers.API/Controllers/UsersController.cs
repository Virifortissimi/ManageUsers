using System;
using ManageUsers.API.Interfaces;
using ManageUsers.API.Models;
using ManageUsersAPI.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManageUsers.API.Controllers
{

    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserServices _userServices;

        public UsersController(
            IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("/user")]
        public IActionResult GetAllUser()
        {
            try
            {
                var allUsers = _userServices.GetUsers();
                return Ok(allUsers);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost("/user")]
        public IActionResult AddUser(UserEntity model)
        {
            try
            {
                var user = _userServices.AddUser(model);
                return new CreatedResult("/user/", new { model = user, message = "Todo Item Created Successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}