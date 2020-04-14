using ToDo.Core.Requests.Profile.Models;
using MediatR;

namespace ToDo.Core.Requests.Profile
{
    public class GetProfile : IRequest<ProfileModel>
    {
    }
}
