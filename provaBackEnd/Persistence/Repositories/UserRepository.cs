using Microsoft.EntityFrameworkCore;
using provaBackEnd.Domain.IRepositories;
using provaBackEnd.Domain.Models;
using provaBackEnd.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace provaBackEnd.Persistence.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ValidateExistence(User user)
        {
            bool response = await _context.Users.AnyAsync(u => u.UserNAme == user.UserNAme);
            return response;
        }
    }
}
