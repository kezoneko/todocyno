using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cynosura.Core.Data;
using ToDo.Core.Entities;
using ToDo.Core.Requests.Tasks.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task = ToDo.Core.Entities.Task;

namespace ToDo.Core.Requests.Tasks
{
    public class GetTaskHandler : IRequestHandler<GetTask, TaskModel>
    {
        private readonly IEntityRepository<Task> _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskHandler(IEntityRepository<Task> taskRepository,
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskModel> Handle(GetTask request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetEntities()
                .Where(e => e.Id == request.Id)
                .FirstOrDefaultAsync();
            return _mapper.Map<Task, TaskModel>(task);
        }

    }
}
