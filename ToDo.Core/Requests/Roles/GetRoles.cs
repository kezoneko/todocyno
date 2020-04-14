using Cynosura.Core.Services.Models;
using ToDo.Core.Infrastructure;
using ToDo.Core.Requests.Roles.Models;
using MediatR;

namespace ToDo.Core.Requests.Roles
{
    public class GetRoles : IRequest<PageModel<RoleModel>>
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }

        public RoleFilter Filter { get; set; }
        public string OrderBy { get; set; }
        public OrderDirection? OrderDirection { get; set; }
    }
}
