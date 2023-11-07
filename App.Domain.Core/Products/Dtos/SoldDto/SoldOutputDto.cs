using App.Domain.Core.Products.Entities;
using App.Domain.Core.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos.SoldDto
{
    public class SoldOutputDto
    {
        public int? Id { get; set; }

        public int? ProductId { get; set; }

        public int? BuyerId { get; set; }

        public bool? IsRemoved { get; set; }
        public DateTime? DateOfRegistration { get; set; } = DateTime.Now;

        public virtual Buyer Buyer { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
