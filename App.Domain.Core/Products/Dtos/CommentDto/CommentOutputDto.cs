using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos.CommentDto
{
    public class CommentOutputDto
    {
        public int? Id { get; set; }
        public string? TextOfComment { get; set; }
        public bool? Status { get; set; }
        public bool? IsRemoved { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
