using System;
using System.Collections.Generic;

namespace apiExamen.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int Chapters { get; set; }

    public int Pages { get; set; }

    public int Price { get; set; }

    public int AuthorId { get; set; }

    public virtual Author? Author { get; set; }
}
