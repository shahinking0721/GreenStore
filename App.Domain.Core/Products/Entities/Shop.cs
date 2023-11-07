using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Core.Products.Entities;

public partial class Shop
{
    [Key]
    public int? Id { get; set; }

    public string? ShopName { get; set; }

    public string? Message { get; set; }

    public string? Sign { get; set; }

    public string? Picture { get; set; }

    public decimal? Wage { get; set; }

    public bool? Status { get; set; }

    public bool? IsRemoved { get; set; }
    [ForeignKey("SellerId")]
    public int SellerId { get; set; }
   
    public virtual Seller Seller { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
