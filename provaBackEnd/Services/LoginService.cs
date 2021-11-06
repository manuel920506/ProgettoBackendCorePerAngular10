using provaBackEnd.Domain.IRepositories;
using provaBackEnd.Domain.IServices;
using provaBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace provaBackEnd.Services
{
    public class LoginService: ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<User> ValidateUser(User user) 
        {
           return await _loginRepository.ValidateUser(user);
        }
    }
}
