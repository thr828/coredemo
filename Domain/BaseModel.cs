using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public class BaseModel
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        [Required]
        public string? CreateUser { get; set; }
        [Required]
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        [Required]
        public string? UpdateUser { get; set; }


    }
}
