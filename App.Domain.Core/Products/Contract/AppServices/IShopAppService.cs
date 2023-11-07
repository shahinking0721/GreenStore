using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Core.Products.Dtos.ShopDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.AppServices
{
    public interface IShopAppService
    {
        Task<string> CreateShop(ShopInputDto shopInputDto, CancellationToken cancellationToken);
        Task<string> Update(ShopInputDto shopInputDto, CancellationToken cancellationToken);
        Task<string> Delete(int Id, CancellationToken cancellationToken);
        Task<List<ShopOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<ShopOutputDto> GetById(int Id, CancellationToken cancellationToken);
        Task<ShopOutputDto> GetBySellerId(int Id, CancellationToken cancellationToken);
    }
}
