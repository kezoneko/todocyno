using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.Entities
{
    public abstract class BaseEntity
    {
        [Required()]
        public int Id { get; set; }
        
        [Required()]
        public DateTime CreationDate { get; set; }
        
        [Required()]
        public DateTime ModificationDate { get; set; }
        

        public int? CreationUserId { get; set; }
        public User CreationUser { get; set; }
        

        public int? ModificationUserId { get; set; }
        public User ModificationUser { get; set; }
        
    }
}
