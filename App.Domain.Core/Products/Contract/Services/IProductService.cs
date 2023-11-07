﻿using App.Domain.Core.Products.Dtos;
using App.Domain.Core.Products.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.Services
{
    public interface IProductService
    {
        Task<int?> CreateProduct(ProductInputDto productInputDto, CancellationToken cancellationToken);
        Task<int?> Update(ProductInputDto productInputDto, CancellationToken cancellationToken);
        Task<int?> Delete(int? Id, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<ProductOutputDto> GetById(int? Id, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetByShopId(int? ShopId, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetByCategoryId(int? CategoryId, CancellationToken cancellationToken);
    }
}
