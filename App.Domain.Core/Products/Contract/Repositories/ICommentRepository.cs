using App.Domain.Core.Products.Dtos.CommentDto;
using App.Domain.Core.Products.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.Repositories
{
    public interface ICommentRepository
    {
        Task<int?> Add(CommentInputDto commentInputDto, CancellationToken cancellationToken);
        Task<int?> Update(CommentInputDto commentInputDto, CancellationToken cancellationToken);
        Task<int?> Delete(int? Id, CancellationToken cancellationToken);
        Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<CommentOutputDto> GetById(int? Id, CancellationToken cancellationToken);
    }
}
