using System;
using System.Collections.Generic;

namespace BookRentalShopApi.Models;

public partial class Division
{
    public string DivCode { get; set; } = null!;

    public string? DivName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
