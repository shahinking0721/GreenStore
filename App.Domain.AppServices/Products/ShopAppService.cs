using App.Domain.Core.Products.Contract.AppServices;
using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Core.Products.Dtos.ShopDto;
using App.Domain.Core.Products.Entities;
using App.Domain.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Products
{
    public class ShopAppService : IShopAppService
    {
        #region  #region Dependency Injection ...

        private readonly IShopService _shopService;

        public ShopAppService(IShopService shopService)
        {
            _shopService = shopService;
        }
        #endregion

        #region Shop AppServices Methods ...
        public async Task<string> CreateShop(ShopInputDto shopInputDto, CancellationToken cancellationToken)
        {
            int? product = await _shopService.CreateShop(shopInputDto, cancellationToken);
            if (product != 0)
                return $"shop with title => {shopInputDto.ShopName} created successfuly";
            else
                return $"cant create shop with title => {shopInputDto.ShopName}"; ;
        }

        public async Task<string> Delete(int Id, CancellationToken cancellationToken)
        {

            int? product = await _shopService.Delete(Id, cancellationToken);
            if (product != 0)
                return $"shop with id => {Id} deleted successfuly";
            else
                return $"cant delete shop with id => {Id}"; ;
        }

        public async Task<string> Update(ShopInputDto shopInputDto, CancellationToken cancellationToken)
        {
            int? product = await _shopService.Update(shopInputDto, cancellationToken);
            if (product != 0)
                return $"shop with title => {shopInputDto.ShopName} created successfuly";
            else
                return $"cant create shop with title => {shopInputDto.ShopName}"; ;
        }

        public async Task<List<ShopOutputDto>> GetAll(CancellationToken cancellationToken)
          => await _shopService.GetAll(cancellationToken);

        public async Task<ShopOutputDto> GetById(int Id, CancellationToken cancellationToken)
          => await _shopService.GetById(Id, cancellationToken);

        public async  Task<ShopOutputDto> GetBySellerId(int Id, CancellationToken cancellationToken)
          => await _shopService.GetBySellerId(Id, cancellationToken);

        #endregion
    }
}
