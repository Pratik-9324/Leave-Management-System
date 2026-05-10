using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Leave_Management_System.Models;

[Table("rolepermissions")]
[Index("PermissionId", Name = "FK_RolePermissions_Permissions")]
[Index("RoleId", "PermissionId", Name = "UQ_Role_Permission", IsUnique = true)]
public partial class Rolepermission
{
    [Key]
    public long RolePermissionId { get; set; }

    public long RoleId { get; set; }

    public long PermissionId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("PermissionId")]
    [InverseProperty("Rolepermissions")]
    public virtual Permission Permission { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("Rolepermissions")]
    public virtual Role Role { get; set; } = null!;
}
