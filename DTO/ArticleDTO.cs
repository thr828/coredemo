using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ArticleDTO: IEntityDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }

        public int Version { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}
