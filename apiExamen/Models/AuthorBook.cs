using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiExamen.Models
{
    public class AuthorBook
    {
        public int id { get; set; }

        public string title { get; set; }

        public int chapters { get; set; }

        public int pages { get; set; }

        public int price { get; set; }

        public string autor { get; set; }
    }
}
