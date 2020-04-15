using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Core.Enums;
using MediatR;

namespace ToDo.Core.Requests.Tasks
{
    public class SetTaskStatusCommand: IRequest
    {
        public int TaskId { get; set; }
        public Status Status { get; set; }
    }

    // Validation Rules
    public class TaskCommandValidator : AbstractValidator<SetTaskStatusCommand>
    {
        public TaskCommandValidator()
        {
            // TaskId is required, not equal to Guid.Empty = NotEmpty()
            RuleFor(x => x.TaskId).NotEmpty();
            // Status is Status
            RuleFor(x => x.Status).NotNull();
        }
    }
}
