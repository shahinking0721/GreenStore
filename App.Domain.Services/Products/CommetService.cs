using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Products.Dtos.CommentDto;
using App.Domain.Core.Products.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Products
{
    internal class CommetService : ICommentService
    {
        #region Dependency Injection ...
        private readonly ICommentRepository _commentRepository;
        public CommetService(ICommentRepository commentRepository)
        {
            this._commentRepository = commentRepository;
        }
        #endregion
        public async Task<int?> CreateComment(CommentInputDto commentInputDto, CancellationToken cancellationToken)
         => await _commentRepository.Add(commentInputDto, cancellationToken);

        public async Task<int?> Delete(int? Id, CancellationToken cancellationToken)
          => await _commentRepository.Delete(Id, cancellationToken);


        public async Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken)
        => await _commentRepository.GetAll(cancellationToken);

        public async Task<CommentOutputDto> GetById(int? Id, CancellationToken cancellationToken)
          => await _commentRepository.GetById(Id, cancellationToken);

        public async Task<int?> Update(CommentInputDto commentInputDto, CancellationToken cancellationToken)
        => await _commentRepository.Update(commentInputDto, cancellationToken);
    }
}
