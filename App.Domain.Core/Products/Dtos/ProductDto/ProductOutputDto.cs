﻿using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos.ProductDto
{
    public class ProductOutputDto
    {
        public int? Id { get; set; }
        public string ProductName { get; set; } = null!;
        public int? NetWeight { get; set; }
        public int? PackageWeight { get; set; }
        public string? SuitableFor { get; set; }
        public string? Discription { get; set; }
        public int Price { get; set; }
        public int? Count { get; set; }
        public int? CategoryId { get; set; }
        public bool? Auction { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? Status { get; set; }
        public int? ShopId { get; set; }
        public string? Picture { get; set; }
        public bool? IsRemoved { get; set; }


        public virtual Category? Category { get; set; }
        public virtual Shop Shop { get; set; } = null!;
        public virtual ICollection<Sold> Solds { get; set; } = new List<Sold>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
