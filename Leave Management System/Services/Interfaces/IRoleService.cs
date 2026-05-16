using Leave_Management_System.DTOs.Roles;

namespace Leave_Management_System.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleResponseDTO>> GetAllRoleAsync();
        Task<RoleResponseDTO?> GetRoleByIdAsync(long roleId);
        Task<RoleResponseDTO> CreateRoleAsync(CreateRoleRequestDTO role);
        Task<bool> UpdateRoleAsync(long roleId,UpdateRoleDTO role);
        Task<bool> DeleteRoleAsync(long roleId);
    }
}
