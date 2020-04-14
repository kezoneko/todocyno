using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cynosura.Core.Data;
using ToDo.Core.Entities;
using ToDo.Core.Infrastructure;
using MediatR;

namespace ToDo.Core.Requests.Tasks
{
    public class CreateTaskHandler : IRequestHandler<CreateTask, CreatedEntity<int>>
    {
        private readonly IEntityRepository<Task> _taskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTaskHandler(IEntityRepository<Task> taskRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreatedEntity<int>> Handle(CreateTask request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<CreateTask, Task>(request);
            _taskRepository.Add(task);
            await _unitOfWork.CommitAsync();
            return new CreatedEntity<int>() { Id = task.Id };
        }

    }
}
