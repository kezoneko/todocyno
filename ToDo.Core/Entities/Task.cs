using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDo.Core.Entities
{
    public class Task : BaseEntity
    {
        [Required()]
        public string Title { get; set; }
        
        [Required()]
        public Enums.Status Status { get; set; }
        
    }
}
