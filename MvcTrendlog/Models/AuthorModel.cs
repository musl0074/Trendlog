using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcTrendlog.Models
{
    public class AuthorModel
    {
        [Key]
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int Earnings { get; set; }
        public string FilePath { get; set; }

    }
}
