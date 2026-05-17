using Leave_Management_System.DTOs.Roles;

namespace Leave_Management_System.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleResponseDTO>> GetAllRoleAsync(CancellationToken cancellationToken = default);
        Task<RoleResponseDTO?> GetRoleByIdAsync(long roleId,CancellationToken cancellationToken = default);
        Task<RoleResponseDTO> CreateRoleAsync(CreateRoleRequestDTO role, CancellationToken cancellationToken = default);
        Task<bool> UpdateRoleAsync(long roleId,UpdateRoleDTO role, CancellationToken cancellationToken = default);
        Task<bool> DeleteRoleAsync(long roleId, CancellationToken cancellationToken = default);
    }
}
