using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Core.Products.Dtos.ShopDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.Services
{
    public interface IShopService
    {
        Task<int?> CreateShop(ShopInputDto shopInputDto, CancellationToken cancellationToken);
        Task<int?> Update(ShopInputDto shopInputDto, CancellationToken cancellationToken);
        Task<int?> Delete(int? Id, CancellationToken cancellationToken);
        Task<List<ShopOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<ShopOutputDto> GetById(int? SellerId, CancellationToken cancellationToken);
        Task<ShopOutputDto> GetBySellerId(int? SellerId, CancellationToken cancellationToken);
    }
}
