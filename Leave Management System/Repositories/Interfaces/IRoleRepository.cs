using Leave_Management_System.DTOs.Roles;
using Leave_Management_System.Models;

namespace Leave_Management_System.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(long id);
        Task<Role?> GetByNameAsync(string roleName);
        Task AddAsync(Role role);
        void UpdateAsync(Role role);
        void DeleteAsync(Role role);
        Task SaveChangesAsync();
    }
}
