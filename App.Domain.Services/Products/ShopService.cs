using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Core.Products.Dtos.ShopDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Products
{
    public class ShopService : IShopService
    {
        #region Dependency Injection ...
        private readonly IShopRepository _shopRepository;
        public ShopService(IShopRepository shopRepository)
        {
            this._shopRepository = shopRepository;
        }
        #endregion

        #region Shop Services Methods ...
        public async Task<int?> CreateShop(ShopInputDto shopInputDto, CancellationToken cancellationToken)
          => await _shopRepository.Add(shopInputDto, cancellationToken);

        public async Task<int?> Delete(int? Id, CancellationToken cancellationToken)
        => await _shopRepository.Delete(Id, cancellationToken);

        public async Task<List<ShopOutputDto>> GetAll(CancellationToken cancellationToken)
        => await _shopRepository.GetAll(cancellationToken);


        public async Task<ShopOutputDto> GetById(int? Id, CancellationToken cancellationToken)
        => await _shopRepository.GetById(Id, cancellationToken);

        public async Task<ShopOutputDto> GetBySellerId(int? SellerId, CancellationToken cancellationToken)
        => await _shopRepository.GetBySellerId(SellerId, cancellationToken);

        public async Task<int?> Update(ShopInputDto shopInputDto, CancellationToken cancellationToken)
        => await _shopRepository.Update(shopInputDto, cancellationToken);
        #endregion

    }
}
