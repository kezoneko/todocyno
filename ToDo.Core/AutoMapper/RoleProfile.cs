using AutoMapper;
using ToDo.Core.Entities;
using ToDo.Core.Requests.Roles;
using ToDo.Core.Requests.Roles.Models;

namespace ToDo.Core.AutoMapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleModel>();
            CreateMap<Role, RoleShortModel>();
            CreateMap<CreateRole, Role>();
            CreateMap<UpdateRole, Role>();
        }
    }
}
