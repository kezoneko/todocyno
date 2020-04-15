using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cynosura.Core.Services.Models;
using ToDo.Core.Requests.Tasks;
using ToDo.Core.Requests.Tasks.Models;
using ToDo.Web.Protos.Tasks;
using Task = ToDo.Core.Requests.Tasks.Models;

namespace ToDo.Web.AutoMapper
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<CreateTaskRequest, CreateTask>()
                .ForMember(dest => dest.Title, opt => opt.Condition(src => src.TitleOneOfCase == CreateTaskRequest.TitleOneOfOneofCase.Title))
                .ForMember(dest => dest.Status, opt => opt.Condition(src => src.StatusOneOfCase == CreateTaskRequest.StatusOneOfOneofCase.Status));
            CreateMap<DeleteTaskRequest, DeleteTask>();
            CreateMap<GetTaskRequest, GetTask>();
            CreateMap<GetTasksRequest, GetTasks>()
                .ForMember(dest => dest.PageIndex, opt => opt.Condition(src => src.PageIndexOneOfCase == GetTasksRequest.PageIndexOneOfOneofCase.PageIndex))
                .ForMember(dest => dest.PageSize, opt => opt.Condition(src => src.PageSizeOneOfCase == GetTasksRequest.PageSizeOneOfOneofCase.PageSize))
                .ForMember(dest => dest.OrderDirection, opt => opt.Condition(src => src.OrderDirectionOneOfCase == GetTasksRequest.OrderDirectionOneOfOneofCase.OrderDirection));
            CreateMap<UpdateTaskRequest, UpdateTask>()
                .ForMember(dest => dest.Title, opt => opt.Condition(src => src.TitleOneOfCase == UpdateTaskRequest.TitleOneOfOneofCase.Title))
                .ForMember(dest => dest.Status, opt => opt.Condition(src => src.StatusOneOfCase == UpdateTaskRequest.StatusOneOfOneofCase.Status));

            CreateMap<TaskModel, Task>()
                .ForMember(dest => dest.Title, opt => opt.Condition(src => src.Title != default))
                .ForMember(dest => dest.Status, opt => opt.Condition(src => src.Status != default));
            CreateMap<PageModel<TaskModel>, TaskPageModel>()                
                .ForMember(dest => dest.PageItems, opt => opt.Ignore())
                .AfterMap((src, dest, rc) => dest.PageItems.AddRange(rc.Mapper.Map<IEnumerable<Task>>(src.PageItems)));
        }
    }
}
