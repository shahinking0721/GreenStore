using App.Domain.Core.Products.Entities;
using App.Domain.Core.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos.ShopDto
{
    public class ShopOutputDto
    {
        public int? Id { get; set; }

        public string? ShopName { get; set; }

        public string? Message { get; set; }

        public string? Sign { get; set; }

        public string? Picture { get; set; }

        public decimal? Wage { get; set; }

        public bool? Status { get; set; }

        public bool? IsRemoved { get; set; }

        public virtual Seller Seller { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();


    }
}
