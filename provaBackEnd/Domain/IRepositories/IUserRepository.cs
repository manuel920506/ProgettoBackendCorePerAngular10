using provaBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace provaBackEnd.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task SaveUser(User user);
        Task<bool> ValidateExistence(User user);
        Task<User> ValidatePassword(int userId, string lastPassword);
        Task UpdatePassword(User user);
    }
}
