using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketSquare.API.Data.Models;
using MarketSquare.API.Data.Repositories;

namespace MarketSquare.API.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepo)
        {
            _userRepository = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        }

        public async Task<IEnumerable<User>> GetUsers() 
        {
            return await _userRepository.GetAllAsync();
        }
    }
}