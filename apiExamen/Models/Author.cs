using System;
using System.Collections.Generic;

namespace apiExamen.Models;

public partial class Author
{
    public int Id { get; set; }

    public string Named { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
