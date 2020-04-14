using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Core.Infrastructure;
using MediatR;

namespace ToDo.Core.Requests.Account
{
    public class Register : IRequest<CreatedEntity<int>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
