using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ToDo.Core.Infrastructure;
using MediatR;

namespace ToDo.Core.Requests.Tasks
{
    public class CreateTask : IRequest<CreatedEntity<int>>
    {
        [DisplayName("Title")]
        public string Title { get; set; }
        [DisplayName("Status")]
        public Enums.Status? Status { get; set; }
    }
}
