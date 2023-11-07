using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Core.Products.Entities;

public partial class Sold
{
    [Key]
    public int? Id { get; set; }
    [ForeignKey("ProductId")]

    public int? ProductId { get; set; }
    [ForeignKey("BuyerId")]

    public int? BuyerId { get; set; }

    public bool? IsRemoved { get; set; }
    public DateTime? DateOfRegistration { get; set; }= DateTime.Now;

    public virtual Buyer Buyer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
