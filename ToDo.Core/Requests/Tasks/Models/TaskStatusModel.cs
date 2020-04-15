using System;
using ToDo.Core.Enums;

namespace ToDo.Core.Requests.Tasks.Models
{
    public class TaskStatusModel
    {
        public string Title { get; set; }

        public Status Status { get; set; }
    }
}
