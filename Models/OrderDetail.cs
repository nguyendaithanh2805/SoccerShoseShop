using SoccerShoesShop.Areas.Admin.Models;
using System;
using System.Collections.Generic;

namespace SoccerShoesShop.Models;

public partial class OrderDetail
{
    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public decimal Discount { get; set; }

    public int Quantity { get; set; }

    public decimal TotalBill { get; set; }

    public virtual TblOrder Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
