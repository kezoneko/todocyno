using ToDo.Core.Requests.Users.Models;
using MediatR;

namespace ToDo.Core.Requests.Users
{
    public class GetUser : IRequest<UserModel>
    {
        public int Id { get; set; }
    }
}
