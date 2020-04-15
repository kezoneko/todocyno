using MediatR;
using AutoMapper;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cynosura.Core.Data;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using Task = ToDo.Core.Entities.Task;

namespace ToDo.Core.Requests.Tasks
{
    public class SetTaskStatusCommandHandler: IRequestHandler<SetTaskStatusCommand>
    {
        private readonly IEntityRepository<Task> _taskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SetTaskStatusCommandHandler(IEntityRepository<Task> taskRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(SetTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetEntities()
                .Where(e => e.Id == request.TaskId)
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
