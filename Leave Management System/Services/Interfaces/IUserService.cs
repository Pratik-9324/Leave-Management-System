using Leave_Management_System.DTOs.User;

namespace Leave_Management_System.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDTO>> GetAllUsers();
    }
}
