using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cynosura.Core.Services.Models;
using ToDo.Core.Requests.Roles;
using ToDo.Core.Requests.Roles.Models;
using ToDo.Web.Protos.Roles;

namespace ToDo.Web.AutoMapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<CreateRoleRequest, CreateRole>();
            CreateMap<DeleteRoleRequest, DeleteRole>();
            CreateMap<GetRoleRequest, GetRole>();
            CreateMap<GetRolesRequest, GetRoles>()
                .ForMember(dest => dest.PageIndex, opt => opt.Condition(src => src.PageIndexOneOfCase == GetRolesRequest.PageIndexOneOfOneofCase.PageIndex))
                .ForMember(dest => dest.PageSize, opt => opt.Condition(src => src.PageSizeOneOfCase == GetRolesRequest.PageSizeOneOfOneofCase.PageSize))
                .ForMember(dest => dest.OrderDirection, opt => opt.Condition(src => src.OrderDirectionOneOfCase == GetRolesRequest.OrderDirectionOneOfOneofCase.OrderDirection));
            CreateMap<UpdateRoleRequest, UpdateRole>();

            CreateMap<RoleModel, Role>();
            CreateMap<PageModel<RoleModel>, RolePageModel>()
                .ForMember(dest => dest.PageItems, opt => opt.Ignore())
                .AfterMap((src, dest, rc) => dest.PageItems.AddRange(rc.Mapper.Map<IEnumerable<Role>>(src.PageItems)));
        }
    }
}
