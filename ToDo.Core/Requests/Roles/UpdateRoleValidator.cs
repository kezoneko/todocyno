using FluentValidation;

namespace ToDo.Core.Requests.Roles
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRole>
    {
        public UpdateRoleValidator()
        {
            RuleFor(x => x.Name).MaximumLength(256).NotEmpty();
        }

    }
}
