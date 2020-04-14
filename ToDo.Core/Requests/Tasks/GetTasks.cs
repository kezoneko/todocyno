using Cynosura.Core.Services.Models;
using ToDo.Core.Infrastructure;
using ToDo.Core.Requests.Tasks.Models;
using MediatR;

namespace ToDo.Core.Requests.Tasks
{
    public class GetTasks : IRequest<PageModel<TaskModel>>
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }

        public TaskFilter Filter { get; set; }
        public string OrderBy { get; set; }
        public OrderDirection? OrderDirection { get; set; }
    }
}
