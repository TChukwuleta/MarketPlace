using Market.Domain.Entities;
using Market.Domain.Interfaces.IRepositories;
using Market.Infrastructure.Data;
using Market.Infrastructure.Services.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Infrastructure.Services.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            try
            {
                var existingUser = await _context.ApplicationUsers.FirstOrDefaultAsync(c => c.Email == email);
                return existingUser;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ApplicationUser> GetUserByUserId(string userId)
        {
            try
            {
                var existingUser = await _context.ApplicationUsers.FirstOrDefaultAsync(c => c.UserId == userId);
                return existingUser;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
