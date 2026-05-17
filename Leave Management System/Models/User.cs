using Leave_Management_System.Common;

namespace Leave_Management_System.Models;

public partial class User : EntityBase
{
    public string EmployeeCode { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string PasswordHash { get; set; } = null!;

    public long RoleId { get; set; }

    public long? ManagerId { get; set; }

    public DateOnly JoiningDate { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public ulong IsFirstLogin { get; set; }

    public string? PasswordResetToken { get; set; }

    public DateTime? PasswordResetTokenExpiry { get; set; }
    public virtual ICollection<User> InverseManager { get; set; } = new List<User>();

    public virtual User? Manager { get; set; }

    public virtual Role Role { get; set; } = null!;
}
