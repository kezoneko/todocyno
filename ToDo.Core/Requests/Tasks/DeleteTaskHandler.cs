using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cynosura.Core.Data;
using ToDo.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task = ToDo.Core.Entities.Task;

namespace ToDo.Core.Requests.Tasks
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTask>
    {
        private readonly IEntityRepository<Task> _taskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaskHandler(IEntityRepository<Task> taskRepository,
            IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteTask request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetEntities()
                .Where(e => e.Id == request.Id)
                .FirstOrDefaultAsync();
            if (task != null)
            {
                _taskRepository.Delete(task);
                await _unitOfWork.CommitAsync();
            }
            return Unit.Value;
        }

    }
}
