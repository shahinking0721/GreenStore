using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Core.Products.Dtos.ShopDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.Repositories
{
    public interface IShopRepository
    {
        Task<int?> Add(ShopInputDto shopInputDto, CancellationToken cancellationToken);
        Task<int?> Update(ShopInputDto shopInputDto, CancellationToken cancellationToken);
        Task<int?> Delete(int? Id, CancellationToken cancellationToken);
        Task<List<ShopOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<ShopOutputDto> GetById(int? Id, CancellationToken cancellationToken);
        Task<ShopOutputDto> GetBySellerId(int? SellerId, CancellationToken cancellationToken);
    }
}
