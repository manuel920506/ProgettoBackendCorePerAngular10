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
     
    public class LoginRepository: ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> ValidateUser(User user)
        {
            User response = await _context.Users.Where(x => x.UserNAme == user.UserNAme 
                                                         && x.Password == user.Password
                                                       ).FirstOrDefaultAsync();
            return response;
        }
    }
}
