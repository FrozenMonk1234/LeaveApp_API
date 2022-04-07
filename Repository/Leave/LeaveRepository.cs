using LeaveApp_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveApp_API.Repository.Leave
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly LeaveDbContext _db;
        public LeaveRepository(LeaveDbContext db)
        {
            _db = db;
        }
        public async Task<bool> CreateLeave(Models.Leave model)
        {
            DateTime start = (DateTime)model.FromDate;
            DateTime end = (DateTime)model.ToDate;

            int leavedays = (start.Date - end.Date).Days;
            var user = await _db.User.Where(x => x.Id == model.UserId).FirstOrDefaultAsync();
            user.LeaveLeft -= leavedays;
            user.LeaveDays += leavedays;
            if(user.LeaveLeft <= 0)
            {
                user.LeaveLeft = 0;
                user.LeaveDays = leavedays;
                model.LeaveLeft = user.LeaveLeft;
                 _db.User.Update(user);

                await _db.Leave.AddAsync(model);

                var save = await _db.SaveChangesAsync();

                return false;
            }
            else
            {
                model.LeaveLeft = user.LeaveLeft;
                _db.User.Update(user);

                await _db.Leave.AddAsync(model);

                var save = await _db.SaveChangesAsync();

                return true;
            }

            
            
        }




        public async Task<List<Models.Leave>> GetAllLeaveByUserId(int Id)
        {
            var result = await _db.Leave.Where(x => x.UserId == Id).ToListAsync();

            return result;
        }

        public async Task<List<TypeOfLeave>> GetAllTypeOfLeave()
        {
            List<TypeOfLeave> result = await _db.TypeOfLeave.ToListAsync();

            if (result.Any())
            {
                return result;
            }
            else
            {

                result.Add(new TypeOfLeave() { Description = "Sick Leave", Value = 1 });
                result.Add(new TypeOfLeave() { Description = "Annual Leave", Value = 1 });
                result.Add(new TypeOfLeave() { Description = "Business Leave", Value = 1 });

                await _db.TypeOfLeave.AddRangeAsync(result);

                var changes = await _db.SaveChangesAsync();
                return result;
            }
        }
    }
}