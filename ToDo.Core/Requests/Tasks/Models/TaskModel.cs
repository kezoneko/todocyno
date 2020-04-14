using System;
using System.Collections.Generic;

namespace ToDo.Core.Requests.Tasks.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public int? CreationUserId { get; set; }
        public Users.Models.UserShortModel CreationUser { get; set; }
        public int? ModificationUserId { get; set; }
        public Users.Models.UserShortModel ModificationUser { get; set; }

        public string Title { get; set; }
        public Enums.Status Status { get; set; }
    }
}
