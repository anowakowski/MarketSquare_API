using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketSquare.API.Data.Models;
using MarketSquare.API.Data.Repositories;
using AutoMapper;
using MarketSquare.API.Dtos;

namespace MarketSquare.API.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;        
        public UserService(IRepository<User> userRepo, IMapper mapper)
        {
            _userRepository = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<UserForDetailedDto>> GetUsers() 
        {
            var users = await _userRepository.GetAllAsync();

            var usersDto = _mapper.Map<UserForDetailedDto>(users);

            return usersDto;
        }
    }
}