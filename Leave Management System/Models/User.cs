using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Leave_Management_System.Models;

[Table("users")]
[Index("Email", Name = "Email", IsUnique = true)]
[Index("EmployeeCode", Name = "EmployeeCode", IsUnique = true)]
[Index("ManagerId", Name = "FK_Users_Manager")]
[Index("RoleId", Name = "FK_Users_Roles")]
public partial class User
{
    [Key]
    public long UserId { get; set; }

    [StringLength(50)]
    public string EmployeeCode { get; set; } = null!;

    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [StringLength(100)]
    public string? LastName { get; set; }

    [StringLength(200)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    [Column(TypeName = "text")]
    public string PasswordHash { get; set; } = null!;

    public long RoleId { get; set; }

    public long? ManagerId { get; set; }

    public DateOnly JoiningDate { get; set; }

    [Required]
    public bool? IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastLoginAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column(TypeName = "bit(1)")]
    public ulong IsFirstLogin { get; set; }

    [InverseProperty("Manager")]
    public virtual ICollection<User> InverseManager { get; set; } = new List<User>();

    [ForeignKey("ManagerId")]
    [InverseProperty("InverseManager")]
    public virtual User? Manager { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; } = null!;
}
