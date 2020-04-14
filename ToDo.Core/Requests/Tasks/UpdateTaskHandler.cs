using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cynosura.Core.Data;
using ToDo.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task = ToDo.Core.Entities.Task;

namespace ToDo.Core.Requests.Tasks
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTask>
    {
        private readonly IEntityRepository<Task> _taskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTaskHandler(IEntityRepository<Task> taskRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTask request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetEntities()
                .Where(e => e.Id == request.Id)
                .FirstOrDefaultAsync();
            if (task != null)
            {
                _mapper.Map(request, task);
                await _unitOfWork.CommitAsync();
            }
            return Unit.Value;
        }

    }
}
