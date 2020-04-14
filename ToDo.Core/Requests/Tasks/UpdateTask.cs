using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ToDo.Core.Requests.Tasks
{
    public class UpdateTask : IRequest
    {
        public int Id { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }
        [DisplayName("Status")]
        public Enums.Status? Status { get; set; }
    }
}
