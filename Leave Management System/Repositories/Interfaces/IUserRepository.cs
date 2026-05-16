

using Leave_Management_System.Models;

namespace Leave_Management_System.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers(); 
    }
}
