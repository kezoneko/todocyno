using ToDo.Core.Requests.Roles.Models;
using MediatR;

namespace ToDo.Core.Requests.Roles
{
    public class GetRole : IRequest<RoleModel>
    {
        public int Id { get; set; }
    }
}
