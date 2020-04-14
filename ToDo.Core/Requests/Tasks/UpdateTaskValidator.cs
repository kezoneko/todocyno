using FluentValidation;

namespace ToDo.Core.Requests.Tasks
{
    public class UpdateTaskValidator : AbstractValidator<UpdateTask>
    {
        public UpdateTaskValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
        }

    }
}
