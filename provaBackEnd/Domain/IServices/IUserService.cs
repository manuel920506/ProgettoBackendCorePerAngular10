using provaBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace provaBackEnd.Domain.IServices
{
    public interface IUserService
    {
        Task SaveUser(User user);
    }
}
