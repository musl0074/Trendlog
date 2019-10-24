using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTrendlog.Models
{
    public class HomeModel
    {
        public int GeneratedLeads { get; set; }
        public int ServerAllocations { get; set; }
        public int SubmittedTickers { get; set; }
        public int GeneratedLeases { get; set; }
        public IEnumerable<AuthorModel> Authors { get; set; }
    }
}
