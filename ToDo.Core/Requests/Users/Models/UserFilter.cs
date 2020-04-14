using System;
using ToDo.Core.Infrastructure;

namespace ToDo.Core.Requests.Users.Models
{
    public class UserFilter : EntityFilter
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
