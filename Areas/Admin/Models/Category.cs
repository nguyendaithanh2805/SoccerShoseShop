using System;
using System.Collections.Generic;

namespace SoccerShoesShop.Areas.Admin.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Name { get; set; } = null;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
