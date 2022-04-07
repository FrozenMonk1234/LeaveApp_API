using LeaveApp_API.Models;
using LeaveApp_API.Repository.Leave;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveApp_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveController : Controller
    {
        private readonly ILeaveRepository _leaveRepository;
        public LeaveController(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        [HttpGet]
        [Route("GetAllLeaveByUserId")]
        public async Task<IActionResult> GetAllLeaveByUserId(int Id)
        {
            try
            {
                var result = await _leaveRepository.GetAllLeaveByUserId(Id);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("CreateLeave")]
        public async Task<IActionResult> CreateLeave(Leave model)
        {
            try
            {
                var result = await _leaveRepository.CreateLeave(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("GetAllTypeOfLeave")]
        public async Task<IActionResult> GetAllTypeOfLeave()
        {
            try
            {
                var result = await _leaveRepository.GetAllTypeOfLeave();
                return Ok(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
