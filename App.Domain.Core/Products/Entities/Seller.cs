using App.Domain.Core.Users.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Core.Products.Entities;

public partial class Seller
{
   [Key]
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? Family { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? IsRemoved { get; set; }

    public virtual Shop? Shop { get; set; }
    [ForeignKey("ApplicationUserId")]

    public int? ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}
