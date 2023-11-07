using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos.AuctionDto
{
    public class AuctionInputDto
    {
        public int? Id { get; set; }

        public int? ProductId { get; set; }

        public int? BuyerId { get; set; }

        public decimal? ProposedPrice { get; set; }

        public DateTime DateOfPropose { get; set; } = DateTime.Now;
        public int? WinnerAuctionId { get; set; }

        public bool IsRemoved { get; set; } = false;

    }
}
