using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Leave_Management_System.Models;

[Table("roles")]
[Index("RoleName", Name = "RoleName", IsUnique = true)]
public partial class Role
{
    [Key]
    public long RoleId { get; set; }

    [StringLength(100)]
    public string RoleName { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<Rolepermission> Rolepermissions { get; set; } = new List<Rolepermission>();

    [InverseProperty("Role")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
