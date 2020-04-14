using Cynosura.Core.Services.Models;
using ToDo.Core.Infrastructure;
using ToDo.Core.Requests.Users.Models;
using MediatR;

namespace ToDo.Core.Requests.Users
{
    public class GetUsers : IRequest<PageModel<UserModel>>
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }

        public UserFilter Filter { get; set; }
        public string OrderBy { get; set; }
        public OrderDirection? OrderDirection { get; set; }
    }
}
