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

        [HttpGet("/user/singleuser")]
        public IActionResult GetAUser(UserEntity model)
        {
            try
            {
                var User = _userServices.GetUser(model);
                return Ok(User);
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

        [HttpDelete("/user/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = _userServices.DeleteUser(id);
                return new OkObjectResult(new { message = "User Deleted successfully", user });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("/user/{id}")]
        public IActionResult UpdateUser(int id, UserEntity model)
        {
            try
            {
                var user = _userServices.UpdateUser(id, model);
                return new CreatedResult("/user/", new { user = user, message = "User Updated Successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPatch("/user/{id}")]
        public IActionResult UpdateUserDetails(int id, UserEntity model)
        {
            try
            {
                var user = _userServices.UpdateUserDetails(id, model);
                return new CreatedResult("/user/", new { user = user, message = "User FirstName Updated Successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}