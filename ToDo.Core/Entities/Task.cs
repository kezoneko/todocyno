using System.ComponentModel.DataAnnotations;

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
