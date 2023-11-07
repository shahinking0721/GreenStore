using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos.SellerDto
{
    public class SellerInputDto
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? Family { get; set; }

        public string? PhoneNumber { get; set; }

        public bool? IsRemoved { get; set; }
        public int? ApplicationUserId { get; set; }

    }
}
