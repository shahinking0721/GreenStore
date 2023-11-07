using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos.BuyerDto
{
    public class BuyerInputDto
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? Family { get; set; }

        public string? PhoneNumber { get; set; }

        public string? PostalCode { get; set; }

        public string? Address { get; set; }
        public int? ApplicationUserId { get; set; }
        public bool? IsRemoved { get; set; }
    }
}
