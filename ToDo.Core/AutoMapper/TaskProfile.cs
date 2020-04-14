using AutoMapper;
using ToDo.Core.Entities;
using ToDo.Core.Requests.Tasks;
using ToDo.Core.Requests.Tasks.Models;

namespace ToDo.Core.AutoMapper
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskModel>();
            CreateMap<Task, TaskShortModel>();
            CreateMap<CreateTask, Task>();
            CreateMap<UpdateTask, Task>();
        }
    }
}
