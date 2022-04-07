using LeaveApp_API.Models;
using LeaveApp_API.Repository.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User model)
        {
            try
            {
                var result = await _userRepository.CreateUser(model);
                return Ok(result);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await _userRepository.GetAllUsers();
                return Ok(result);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User model)
        {
            try
            {
                var result = await _userRepository.UpdateUser(model);
                return Ok(result);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
