using System;
using System.Collections.Generic;

namespace SoccerShoesShop.Models;

public partial class TblOrder
{
    public int OrderId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public int UserId { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly DeliveryDate { get; set; }

    public bool Status { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Account? User { get; set; } = null;
}
