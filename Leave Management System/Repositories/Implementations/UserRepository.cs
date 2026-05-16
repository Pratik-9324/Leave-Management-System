
using Leave_Management_System.Data;
using Leave_Management_System.Models;
using Leave_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Leave_Management_System.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
