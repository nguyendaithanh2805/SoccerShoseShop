﻿using System;
using System.Collections.Generic;

namespace SoccerShoesShop.Models;

public partial class Account
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
    public virtual Role? Role { get; set; } = null;
}
