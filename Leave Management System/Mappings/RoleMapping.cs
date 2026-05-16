using AutoMapper;
using Leave_Management_System.DTOs.Roles;
using Leave_Management_System.Models;

namespace Leave_Management_System.Mappings;

public class RoleMapping:Profile
{
    public RoleMapping()
    {
        CreateMap<CreateRoleRequestDTO,Role>();
        CreateMap<Role,RoleResponseDTO>();
    }   
}
