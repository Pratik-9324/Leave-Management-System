using FluentValidation;
using Leave_Management_System.DTOs.Roles;

namespace Leave_Management_System.Validators.Roles;

public class UpdateRoleValidator:AbstractValidator<UpdateRoleDTO>
{
    public UpdateRoleValidator()
    {
        RuleFor(x => x.RoleName).NotEmpty().WithMessage("The role name is required.").MaximumLength(100).WithMessage("Role name cannot exceed 100 characters.");
        RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
    }
}
