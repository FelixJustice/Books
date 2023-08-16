using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Books.Models;

[Table("books")]
[Index("Title", "Author", "Year", IsUnique = true)]
public partial class Book
{
    [Key]
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public long Year { get; set; }

    public string? Publisher { get; set; }

    public string? Description { get; set; }
}
