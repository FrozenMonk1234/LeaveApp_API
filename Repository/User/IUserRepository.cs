using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveApp_API.Repository.User
{
    public interface IUserRepository
    {
        Task<Models.User> CreateUser(Models.User model);
        Task<List<Models.User>> GetAllUsers();
        Task<Models.User> UpdateUser(Models.User model);
    }
}
