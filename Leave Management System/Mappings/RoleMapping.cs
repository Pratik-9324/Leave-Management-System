using AutoMapper;
using Leave_Management_System.DTOs.Roles;
using Leave_Management_System.Models;

namespace Leave_Management_System.Mappings;

public class RoleMapping:Profile
{
    public RoleMapping()
    {
        CreateMap<CreateRoleRequestDTO,Role>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
        CreateMap<UpdateRoleDTO,Role>();
        CreateMap<Role,RoleResponseDTO>()
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id));
    }   
}
