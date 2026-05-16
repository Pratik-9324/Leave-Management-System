using Leave_Management_System.Data;
using Leave_Management_System.DTOs.Roles;
using Leave_Management_System.Models;
using Leave_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Leave_Management_System.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles.AsNoTracking().ToListAsync();
        }
        public async Task<Role?> GetByIdAsync(long id)
        {
            return await _context.Roles.FirstOrDefaultAsync(u => u.RoleId == id);
        }

        public async Task<Role?> GetByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(u => u.RoleName == roleName);
        }
        public async Task AddAsync(Role role)
        {
            await _context.AddAsync(role);
        }
        public void UpdateAsync(Role role)
        {
            _context.Roles.Update(role);
        }

        public void DeleteAsync(Role role)
        {
            _context.Roles.Remove(role);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
