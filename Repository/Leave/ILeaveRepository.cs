using LeaveApp_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveApp_API.Repository.Leave
{
    public interface ILeaveRepository
    {
        Task<List<Models.Leave>> GetAllLeaveByUserId(int Id);
        Task<bool> CreateLeave(Models.Leave model);
        Task<List<TypeOfLeave>> GetAllTypeOfLeave();
    }
}
