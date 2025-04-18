﻿using SoccerShoesShop.Areas.Admin.Models;
using System;
using System.Collections.Generic;

namespace SoccerShoesShop.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalBill { get; set; }

    public virtual Product? Product { get; set; } = null;

    public virtual Account? User { get; set; } = null;
}
