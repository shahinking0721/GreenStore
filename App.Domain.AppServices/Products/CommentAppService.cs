using App.Domain.Core.Products.Contract.AppServices;
using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Products.Dtos.CommentDto;
using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Products
{
    public class CommentAppService : ICommentAppService
    {
        #region  #region Dependency Injection ...

        private readonly ICommentService _commentService;

        public CommentAppService(ICommentService commentService)
        {
            _commentService = commentService;
        }
        #endregion
        public async Task<string> CreateComment(CommentInputDto commentInputDto, CancellationToken cancellationToken)
        {
            int? product = await _commentService.CreateComment(commentInputDto, cancellationToken);
            if (product != 0)
                return $"comment with id = {commentInputDto.Id} created successfuly";
            else
                return $"cant create comment with id = {commentInputDto.Id}";
        }

        public async Task<string> Delete(int Id, CancellationToken cancellationToken)
        {
            int? result = await _commentService.Delete(Id, cancellationToken);
            if (result != 0)
                return $"comment with id = {Id} deleted successfuly";
            else
                return $"comment with id = {Id} not found";
        }

        public async Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken)
        => await _commentService.GetAll(cancellationToken);

        public async Task<CommentOutputDto> GetById(int Id, CancellationToken cancellationToken)
         => await _commentService.GetById(Id, cancellationToken);

        //Returns all comments related to a specific product
        public async Task<List<CommentOutputDto>> GetByProductId(int productId, CancellationToken cancellationToken)
        {
           IEnumerable<CommentOutputDto> result = (IEnumerable<CommentOutputDto>) await _commentService.GetAll(cancellationToken);
            List<CommentOutputDto> outPutResult =new List<CommentOutputDto>();
            foreach (var item in result)
            {
                if(item.ProductId== productId) outPutResult.Add(item);
            }
            return outPutResult; ;
        }
        

        public async Task<string> Update(CommentInputDto commentInputDto, CancellationToken cancellationToken)
        {
            int? result = await _commentService.Update(commentInputDto, cancellationToken);
            if (result != 0)
                return $"comment with id = {commentInputDto.Id} edited successfuly";
            else
                return $"comment with id = {commentInputDto.Id} not edited";
        }
    }
}
