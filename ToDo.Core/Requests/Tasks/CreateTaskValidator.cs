using FluentValidation;

namespace ToDo.Core.Requests.Tasks
{
    public class CreateTaskValidator : AbstractValidator<CreateTask>
    {
        public CreateTaskValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
        }

    }
}
