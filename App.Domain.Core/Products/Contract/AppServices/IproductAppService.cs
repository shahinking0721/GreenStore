using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.AppServices
{
    public interface IproductAppService
    {
        Task<string> CreateProduct(ProductInputDto productInputDto, CancellationToken cancellationToken);
        Task<string> Update(ProductInputDto productInputDto, CancellationToken cancellationToken);
        Task<string> Delete(int Id, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<ProductOutputDto> GetById(int Id, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetByShopId(int ShopId, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetByCategoryId(int CategoryId, CancellationToken cancellationToken);
    }

   
}
