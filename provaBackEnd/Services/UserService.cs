using provaBackEnd.Domain.IRepositories;
using provaBackEnd.Domain.IServices;
using provaBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace provaBackEnd.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task SaveUser(User user)
        {
            await _userRepository.SaveUser(user);
        }

        public async Task<bool> ValidateExistence(User user)
        {
            bool response = await _userRepository.ValidateExistence(user);
            return response;
        }
    }
}
