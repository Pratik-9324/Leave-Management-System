using Leave_Management_System.Common;

namespace Leave_Management_System.Models;

public partial class Permission : EntityBase
{
    public string PermissionName { get; set; } = null!;
    public string ModuleName { get; set; } = null!;
    public string? Description { get; set; }
    public virtual ICollection<Rolepermission> Rolepermissions { get; set; } = new List<Rolepermission>();
}
