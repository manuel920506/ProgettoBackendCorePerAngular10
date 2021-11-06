using provaBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace provaBackEnd.Domain.IServices
{
    public interface ILoginService
    {
        Task<User> ValidateUser(User user);
    }
}
