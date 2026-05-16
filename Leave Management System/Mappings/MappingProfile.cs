using AutoMapper;
using Leave_Management_System.DTOs.User;
using Leave_Management_System.Models;

namespace Leave_Management_System.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponseDTO>();
        }
    }
}
