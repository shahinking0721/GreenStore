using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Products.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Products.Contract.AppServices;
using App.Domain.Core.Products.Entities;
using App.Domain.Services.Products;

namespace App.Domain.AppServices.Products
{
    public class ProductAppService:IproductAppService
    {
        #region  #region Dependency Injection ...

        private readonly IProductService _productService;

        public ProductAppService(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        #region Product AppServices Methods ...
        public async Task<string> CreateProduct(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            int? product = await _productService.CreateProduct(productInputDto, cancellationToken);
            if (product != 0)
                return $"product with titleid = {productInputDto.ProductName} created successfuly";
            else
                return $"cant create product with titleid = {productInputDto.ProductName}";
        }

        public async Task<string> Update(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            int? result = await _productService.Update(productInputDto, cancellationToken);
            if (result != 0)
                return $"product with id = {productInputDto.Id} edited successfuly";
            else
                return $"product with id = {productInputDto.Id} not edited";
        }

        public async Task<string> Delete(int Id, CancellationToken cancellationToken)
        {
            int? result = await _productService.Delete(Id, cancellationToken);
            if (result == 1)
                return $"product with id = {Id} deleted successfuly";
            else
                return $"product with id = {Id} not found";

        }

        public async Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken) 
            => await _productService.GetAll(cancellationToken);
       
        public async Task<ProductOutputDto> GetById(int Id, CancellationToken cancellationToken)
            => await _productService.GetById(Id, cancellationToken);

        public async Task<List<ProductOutputDto>> GetByShopId(int ShopId, CancellationToken cancellationToken)
        => await _productService.GetByShopId(ShopId, cancellationToken);

        public async Task<List<ProductOutputDto>> GetByCategoryId(int CategoryId, CancellationToken cancellationToken)
         => await _productService.GetByCategoryId(CategoryId, cancellationToken);
        #endregion

    }
}
