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
    }
}
