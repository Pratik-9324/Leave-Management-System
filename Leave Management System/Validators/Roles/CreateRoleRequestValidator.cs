using FluentValidation;
using Leave_Management_System.DTOs.Roles;

namespace Leave_Management_System.Validators.Roles
{
    public class CreateRoleRequestValidator:AbstractValidator<CreateRoleRequestDTO>
    {
        public CreateRoleRequestValidator() {
            RuleFor(x => x.RoleName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(100);
        }
    }
}
