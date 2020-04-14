using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ToDo.Core.Entities;
using ToDo.Core.Requests.Account;

namespace ToDo.Core.AutoMapper
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Register, User>();
        }
    }
}
