using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Core.Products.Entities;

public partial class Comment
{
    [Key]
    public int?  Id { get; set; }
    public string? TextOfComment { get; set; }
    public bool? Status { get; set; }
    public bool? IsRemoved { get; set; }
    [ForeignKey("ProductId")]

    public int? ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

   
}
