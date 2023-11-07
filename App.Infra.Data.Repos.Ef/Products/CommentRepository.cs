using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Dtos.CommentDto;
using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Core.Products.Entities;
using App.Infra.Data.SqlServer.Ef.DbCTX;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Products
{
    public class CommentRepository : ICommentRepository
    {
        #region  Dependency Injection ...
        private readonly GreenStoreDbContext _context;
        public CommentRepository(GreenStoreDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Comment Repository Methods...
        public async Task<int?> Add(CommentInputDto commentInputDto, CancellationToken cancellationToken)
        {
            Comment product = new Comment
            {
                Id =commentInputDto.Id,
                //ProductId = commentInputDto.ProductId,
                IsRemoved =false,
                Status = commentInputDto.Status,
                TextOfComment = commentInputDto.TextOfComment,
                
            };

            await _context.Comments.AddAsync(product);
            var result = await _context.SaveChangesAsync();
            if (result != 0)
                return product.Id;

            return 0;
        }

        public async Task<int?> Delete(int? Id, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FindAsync(Id);
            comment.IsRemoved = true;
            int result = await _context.SaveChangesAsync();
            if (result != 0)
                return comment.Id;
            return 0;
        }

        public async Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var commentList = await _context.Comments.AsNoTracking().Select(p => new CommentOutputDto
            {
                Id = p.Id,
               TextOfComment=p.TextOfComment,
               IsRemoved=p.IsRemoved,
               Status = p.Status,
               //ProductId=p.ProductId,
               //Product = p.Product
            }).ToListAsync();
            return commentList;
        }

        public async Task<CommentOutputDto> GetById(int? Id, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(p => p.Id == Id);
            var ProductDto = new CommentOutputDto
            {
                Id = comment.Id,
                TextOfComment = comment.TextOfComment,
                IsRemoved=comment.IsRemoved,
                //ProductId=comment.ProductId,
                //Product = comment.Product
            };
            return ProductDto;
        }

        public async Task<int?> Update(CommentInputDto commentInputDto, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FindAsync(commentInputDto.Id);

            comment.Id = commentInputDto.Id;
            //comment.ProductId = commentInputDto.ProductId;
            comment.Status = commentInputDto.Status;
            comment.IsRemoved = commentInputDto.IsRemoved;
            comment.TextOfComment = commentInputDto.TextOfComment;
            int result = await _context.SaveChangesAsync();
            if (result != 0)
                return comment.Id;
            return 0;
        }
        #endregion
    }
}
