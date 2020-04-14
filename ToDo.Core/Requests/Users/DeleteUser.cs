using MediatR;

namespace ToDo.Core.Requests.Users
{
    public class DeleteUser : IRequest
    {
        public int Id { get; set; }
    }
}
