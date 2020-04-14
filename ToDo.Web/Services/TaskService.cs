using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cynosura.Core.Services.Models;
using ToDo.Core.Infrastructure;
using ToDo.Core.Requests.Tasks;
using ToDo.Core.Requests.Tasks.Models;
using ToDo.Web.Protos;
using ToDo.Web.Protos.Tasks;
using Grpc.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Task = ToDo.Web.Protos.Tasks.Task;

namespace ToDo.Web.Services
{
    [Authorize("ReadTask")]
    public class TaskService : Protos.Tasks.TaskService.TaskServiceBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TaskService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override async Task<TaskPageModel> GetTasks(GetTasksRequest getTasksRequest, ServerCallContext context)
        {
            var getTasks = _mapper.Map<GetTasksRequest, GetTasks>(getTasksRequest);
            return _mapper.Map<PageModel<TaskModel>, TaskPageModel>(await _mediator.Send(getTasks));
        }

        public override async Task<Task> GetTask(GetTaskRequest getTaskRequest, ServerCallContext context)
        {
            var getTask = _mapper.Map<GetTaskRequest, GetTask>(getTaskRequest);
            return _mapper.Map<TaskModel, Task>(await _mediator.Send(getTask));
        }

        [Authorize("WriteTask")]
        public override async Task<Empty> UpdateTask(UpdateTaskRequest updateTaskRequest, ServerCallContext context)
        {
            var updateTask = _mapper.Map<UpdateTaskRequest, UpdateTask>(updateTaskRequest);
            return _mapper.Map<Unit, Empty>(await _mediator.Send(updateTask));
        }

        [Authorize("WriteTask")]
        public override async Task<CreatedEntity> CreateTask(CreateTaskRequest createTaskRequest, ServerCallContext context)
        {
            var createTask = _mapper.Map<CreateTaskRequest, CreateTask>(createTaskRequest);
            return _mapper.Map<CreatedEntity<int>, CreatedEntity>(await _mediator.Send(createTask));
        }

        [Authorize("WriteTask")]
        public override async Task<Empty> DeleteTask(DeleteTaskRequest deleteTaskRequest, ServerCallContext context)
        {
            var deleteTask = _mapper.Map<DeleteTaskRequest, DeleteTask>(deleteTaskRequest);
            return _mapper.Map<Unit, Empty>(await _mediator.Send(deleteTask));
        }
    }
}
