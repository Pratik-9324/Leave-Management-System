using AutoMapper;
using Leave_Management_System.DTOs.User;
using Leave_Management_System.Repositories.Interfaces;
using Leave_Management_System.Services.Interfaces;
using System.Runtime.InteropServices;

namespace Leave_Management_System.Services.Implementations
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserResponseDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return _mapper.Map<List<UserResponseDTO>>(users);
        }
    }
}
