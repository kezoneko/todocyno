using System;
using System.Threading.Tasks;
using Cynosura.Core.Services.Models;
using ToDo.Core.Infrastructure;
using ToDo.Core.Requests.Tasks;
using ToDo.Core.Requests.Tasks.Models;
using ToDo.Web.Models;
using Cynosura.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Web.Controllers
{
    [ServiceFilter(typeof(ApiExceptionFilterAttribute))]
    [Authorize("ReadTask")]
    [ValidateModel]
    [Route("api")]
    public class TaskController : Controller
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetTasks")]
        public async Task<PageModel<TaskModel>> GetTasksAsync([FromBody] GetTasks getTasks)
        {
            return await _mediator.Send(getTasks);
        }

        [HttpPost("GetTask")]
        public async Task<TaskModel> GetTaskAsync([FromBody] GetTask getTask)
        {
            return await _mediator.Send(getTask);
        }

        [Authorize("WriteTask")]
        [HttpPost("UpdateTask")]
        public async Task<Unit> UpdateTaskAsync([FromBody] UpdateTask updateTask)
        {
            return await _mediator.Send(updateTask);
        }

        [Authorize("WriteTask")]
        [HttpPost("CreateTask")]
        public async Task<CreatedEntity<int>> CreateTaskAsync([FromBody] CreateTask createTask)
        {
            return await _mediator.Send(createTask);
        }

        [Authorize("WriteTask")]
        [HttpPost("DeleteTask")]
        public async Task<Unit> DeleteTaskAsync([FromBody] DeleteTask deleteTask)
        {
            return await _mediator.Send(deleteTask);
        }
    }
}