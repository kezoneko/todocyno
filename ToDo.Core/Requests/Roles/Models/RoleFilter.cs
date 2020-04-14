using System;
using ToDo.Core.Infrastructure;

namespace ToDo.Core.Requests.Roles.Models
{
    public class RoleFilter : EntityFilter
    {
        public string Name { get; set; }
    }
}
