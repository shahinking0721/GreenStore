using App.Domain.Core.Products.Entities;
using App.Domain.Core.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos.BuyerDto
{
    public class BuyerOutputDto
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? Family { get; set; }

        public string? PhoneNumber { get; set; }

        public string? PostalCode { get; set; }

        public string? Address { get; set; }

        public bool? IsRemoved { get; set; }
        public int? ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Sold> Solds { get; set; } = new List<Sold>();
    }
}
