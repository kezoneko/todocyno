using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ToDo.Core.Infrastructure;
using MediatR;

namespace ToDo.Core.Requests.Roles
{
    public class CreateRole : IRequest<CreatedEntity<int>>
    {
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
