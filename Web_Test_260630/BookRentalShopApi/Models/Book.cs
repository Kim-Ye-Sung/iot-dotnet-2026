using System;
using System.Collections.Generic;

namespace BookRentalShopApi.Models;

public partial class Book
{
    public int BookIdx { get; set; }

    public string? Author { get; set; }

    public string DivCode { get; set; } = null!;

    public string? BookName { get; set; }

    public DateOnly? ReleaseDt { get; set; }

    public string? Isbn { get; set; }

    public decimal? Price { get; set; }

    public virtual Division DivCodeNavigation { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
