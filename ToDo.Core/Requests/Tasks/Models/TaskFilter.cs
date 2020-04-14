using System;
using ToDo.Core.Infrastructure;

namespace ToDo.Core.Requests.Tasks.Models
{
    public class TaskFilter : EntityFilter
    {
        public string Title { get; set; }
        public Enums.Status? Status { get; set; }
    }
}
