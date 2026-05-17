using System;
using System.Collections.Generic;

namespace Leave_Management_System.Models;

public partial class Rolepermission
{
    public long RolePermissionId { get; set; }

    public long RoleId { get; set; }

    public long PermissionId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
