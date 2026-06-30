using System;
using System.Collections.Generic;

namespace BookRentalShopApi.Models;

public partial class Rental
{
    public int RentalIdx { get; set; }

    public int MemberIdx { get; set; }

    public int BookIdx { get; set; }

    public DateOnly? RentalDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public virtual Book BookIdxNavigation { get; set; } = null!;

    public virtual Member MemberIdxNavigation { get; set; } = null!;
}
