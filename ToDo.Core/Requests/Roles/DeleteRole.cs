using MediatR;

namespace ToDo.Core.Requests.Roles
{
    public class DeleteRole : IRequest
    {
        public int Id { get; set; }
    }
}
