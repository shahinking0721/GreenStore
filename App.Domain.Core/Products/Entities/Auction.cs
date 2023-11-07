using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace App.Domain.Core.Products.Entities;

public partial class Auction
{
    [Key]
    public int? Id { get; set; }
    [ForeignKey("ProductId")]

    public int? ProductId { get; set; }
    [ForeignKey("BuyerId")]

    public int? BuyerId { get; set; }

    public decimal? ProposedPrice { get; set; }

    public DateTime DateOfPropose { get; set; }= DateTime.Now;
    public int? WinnerAuctionId { get; set; }

    public bool IsRemoved { get; set; }= false;

    public virtual Buyer Buyer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
