using AutoMapper;
using ToDo.Core.Entities;
using ToDo.Core.Requests.Profile.Models;

namespace ToDo.Core.AutoMapper
{
    public class ProfileProfile : Profile
    {
        public ProfileProfile()
        {
            CreateMap<User, ProfileModel>();
        }
    }
}
