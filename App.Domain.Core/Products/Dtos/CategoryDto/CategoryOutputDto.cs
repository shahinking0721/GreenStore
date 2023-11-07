using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos.CategoryDto
{
    public class CategoryOutputDto
    {
        public int? Id { get; set; }

        public string CategoryName { get; set; } = null!;

        public string? CategoryPicrure { get; set; }

        public bool? IsRemoved { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
