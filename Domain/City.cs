using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? AreaCode { get; set; }

        public int ProviceId { get; set; }

    }
}
