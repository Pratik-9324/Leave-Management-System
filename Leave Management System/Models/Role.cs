using Leave_Management_System.Common;

namespace Leave_Management_System.Models;

public partial class Role : EntityBase
{
    public string RoleName { get; set; } = null!;

    public string? Description { get; set; }
    public virtual ICollection<Rolepermission> Rolepermissions { get; set; } = new List<Rolepermission>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
