using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Leave_Management_System.Models;

[Table("permissions")]
[Index("PermissionName", Name = "PermissionName", IsUnique = true)]
public partial class Permission
{
    [Key]
    public long PermissionId { get; set; }

    [StringLength(200)]
    public string PermissionName { get; set; } = null!;

    [StringLength(100)]
    public string ModuleName { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Permission")]
    public virtual ICollection<Rolepermission> Rolepermissions { get; set; } = new List<Rolepermission>();
}
