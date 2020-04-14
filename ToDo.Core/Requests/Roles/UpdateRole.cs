using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ToDo.Core.Requests.Roles
{
    public class UpdateRole : IRequest
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
