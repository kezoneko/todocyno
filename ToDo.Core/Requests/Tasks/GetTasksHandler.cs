using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cynosura.Core.Data;
using Cynosura.Core.Services.Models;
using ToDo.Core.Entities;
using ToDo.Core.Requests.Tasks.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task = ToDo.Core.Entities.Task;

namespace ToDo.Core.Requests.Tasks
{
    public class GetTasksHandler : IRequestHandler<GetTasks, PageModel<TaskModel>>
    {
        private readonly IEntityRepository<Task> _taskRepository;
        private readonly IMapper _mapper;

        public GetTasksHandler(IEntityRepository<Task> taskRepository,
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<PageModel<TaskModel>> Handle(GetTasks request, CancellationToken cancellationToken)
        {
            IQueryable<Task> query = _taskRepository.GetEntities();            
            query = query.Filter(request.Filter);
            query = query.OrderBy(request.OrderBy, request.OrderDirection);
            var tasks = await query.ToPagedListAsync(request.PageIndex, request.PageSize);
            return tasks.Map<Task, TaskModel>(_mapper);
        }

    }
}
