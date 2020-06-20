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
                return new CreatedResult("/user/", new { user = user, message = "User Created Successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpDelete("/user")]
        public IActionResult DeleteUser(UserEntity model)
        {
            try
            {
                var user = _userServices.DeleteUser(model);
                return new OkObjectResult(new { message = "User Deleted successfully", user });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("/user")]
        public IActionResult UpdateUser(UserEntity model)
        {
            try
            {
                var user = _userServices.UpdateUser(model);
                return new CreatedResult("/user/", new { user = user, message = "User Updated Successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}