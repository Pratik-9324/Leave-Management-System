namespace Leave_Management_System.DTOs.Roles;

public class UpdateRoleDTO
{
    public string RoleName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}
