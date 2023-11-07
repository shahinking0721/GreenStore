using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Products.Dtos;
using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.Services.Products
{
    public class ProductService : IProductService
    {

        #region Dependency Injection ...
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        #endregion

        #region Product Services Methods ...
        public async Task<int?> CreateProduct(ProductInputDto productInputDto, CancellationToken cancellationToken)
         =>  await _productRepository.Add(productInputDto, cancellationToken);
            
        public async Task<int?> Delete(int? Id, CancellationToken cancellationToken)
        => await _productRepository.Delete(Id, cancellationToken);

        public async Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken)
        => await _productRepository.GetAll(cancellationToken);

        public async Task<List<ProductOutputDto>> GetByCategoryId(int? CategoryId, CancellationToken cancellationToken)
          => await _productRepository.GetByCategoryId(CategoryId, cancellationToken);


        public async Task<ProductOutputDto> GetById(int? Id, CancellationToken cancellationToken)
        => await _productRepository.GetById(Id, cancellationToken);

        public async Task<List<ProductOutputDto>> GetByShopId(int? ShopId, CancellationToken cancellationToken)
         => await _productRepository.GetByShopId(ShopId, cancellationToken);

        public async Task<int?> Update(ProductInputDto productInputDto, CancellationToken cancellationToken)
        => await _productRepository.Update(productInputDto, cancellationToken);
        #endregion

    }
}
