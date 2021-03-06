using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cynosura.Core.Data;
using Cynosura.Core.Services.Models;
using ToDo.Core.Entities;
using ToDo.Core.Requests.Roles.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ToDo.Core.Requests.Roles
{
    public class GetRolesHandler : IRequestHandler<GetRoles, PageModel<RoleModel>>
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IEntityRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public GetRolesHandler(RoleManager<Role> roleManager, IEntityRepository<Role> roleRepository, IMapper mapper)
        {
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<PageModel<RoleModel>> Handle(GetRoles request, CancellationToken cancellationToken)
        {
            IQueryable<Role> query = _roleManager.Roles;
            query = query.Filter(request.Filter);
            query = query.OrderBy(request.OrderBy, request.OrderDirection);
            var roles = await query.ToPagedListAsync(request.PageIndex, request.PageSize);
            return roles.Map<Role, RoleModel>(_mapper);
        }

    }
}
