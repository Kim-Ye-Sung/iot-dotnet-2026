using System;
using System.Collections.Generic;

namespace BookRentalShopApi.Models;

public partial class Member
{
    public int MemberIdx { get; set; }

    public string MemberName { get; set; } = null!;

    public string? Levels { get; set; }

    public string? Address { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
