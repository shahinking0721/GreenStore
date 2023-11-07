using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Products.Entities;

public partial class Category
{
    [Key]
    public int? Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryPicrure { get; set; }

    public bool? IsRemoved { get; set; }

    public virtual Product Product { get; set; } = null!;
}
