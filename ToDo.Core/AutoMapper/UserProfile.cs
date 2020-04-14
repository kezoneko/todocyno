using AutoMapper;
using ToDo.Core.Entities;
using ToDo.Core.Requests.Users;
using ToDo.Core.Requests.Users.Models;

namespace ToDo.Core.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<User, UserShortModel>();
            CreateMap<CreateUser, User>();
            CreateMap<UpdateUser, User>();
        }
    }
}
