using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Core.Products.Entities;

public partial class Product
{
    [Key]
    public int? Id { get; set; }
    public string ProductName { get; set; } = null!;
    public int? NetWeight { get; set; }
    public int? PackageWeight { get; set; }
    public string? SuitableFor { get; set; }
    public string? Discription { get; set; }
    public int Price { get; set; }
    public int? Count { get; set; }
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public bool? Auction { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public bool? Status { get; set; }
    [ForeignKey("ShopId")]

    public int? ShopId { get; set; }
    public string? Picture { get; set; }
    public bool? IsRemoved { get; set; }

    public virtual Auction? Auctions { get; set; }
    public virtual Category? Category { get; set; }
    public virtual Shop Shop { get; set; } = null!;
    public virtual ICollection<Sold> Solds { get; set; } = new List<Sold>();
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
