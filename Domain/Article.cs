using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("T_Acticle")]
    public class Article:BaseModel
    {
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Author { get; set; } 

        public int Version { get; set; }
                  
    }
}
