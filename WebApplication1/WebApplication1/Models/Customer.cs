using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
