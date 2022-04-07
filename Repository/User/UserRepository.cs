using LeaveApp_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveApp_API.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly LeaveDbContext _db;
        public UserRepository(LeaveDbContext db)
        {
            _db = db;
        }
        public async Task<Models.User> CreateUser(Models.User model)
        {
            Models.User result = new Models.User();
            var checkDb = await _db.User.Where(x => x.FirstName == model.FirstName || x.LastName == model.LastName).FirstOrDefaultAsync();
            if (checkDb == null)
            {
                await _db.User.AddAsync(model);

                var save = await _db.SaveChangesAsync();
                if (save > 0)
                {
                    result = await _db.User.Where(x => x.FirstName == model.FirstName && x.LastName == model.LastName).FirstOrDefaultAsync();
                    return result;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return checkDb;
            }

        }

        public async Task<List<Models.User>> GetAllUsers()
        {
            var result = await _db.User.Where( x=> x.IsActive == true).ToListAsync();

            return result;
        }

        public async Task<Models.User> UpdateUser(Models.User model)
        {
            var result =  _db.User.Update(model).Entity;

            return await Task.FromResult(result);
        }
    }
}
