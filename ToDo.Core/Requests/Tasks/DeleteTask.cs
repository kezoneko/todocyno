using System;
using MediatR;

namespace ToDo.Core.Requests.Tasks
{
    public class DeleteTask : IRequest
    {
        public int Id { get; set; }
    }
}
