using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos.ShopDto
{
    public class ShopInputDto
    {
        public int?   Id { get; set; }

        public string? ShopName { get; set; }

        public string? Message { get; set; }

        public string? Sign { get; set; }

        public string? Picture { get; set; }

        public decimal? Wage { get; set; }

        public bool? Status { get; set; }

        public bool? IsRemoved { get; set; }
    }
}
