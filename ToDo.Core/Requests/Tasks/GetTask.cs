using System;
using ToDo.Core.Requests.Tasks.Models;
using MediatR;

namespace ToDo.Core.Requests.Tasks
{
    public class GetTask : IRequest<TaskModel>
    {
        public int Id { get; set; }
    }
}
