using System;
using System.Collections.Generic;
using SoccerShoesShop.Areas.Admin.Models;

namespace SoccerShoesShop.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal? Discount { get; set; }

    public string Image { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal SellingPrice { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
