using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Comment : BaseModel
    {
        [Required]
        public string? Content {get;set;}
        [IgnoreDataMember]
        public Article? BeArticle { get; set; }
    }
}
