using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Core.Products.Entities;
using App.Infra.Data.SqlServer.Ef.DbCTX;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Products
{
    public class ProductRepository : IProductRepository
    {
        #region Dependency Injection ...
        private readonly GreenStoreDbContext _context;

        public ProductRepository(GreenStoreDbContext context)
        {
            _context = context;
        }
        #endregion

        #region  Product Repository Methods...
        public async Task<int?> Add(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            Product product = new Product
            {
                Id = productInputDto.Id,
                ProductName = productInputDto.ProductName,
                NetWeight = productInputDto.NetWeight,
                PackageWeight = productInputDto.PackageWeight,
                Discription=productInputDto.Discription,
                Auction=productInputDto.Auction,
                Count=productInputDto.Count,
                FromDate=productInputDto.FromDate,
                ToDate=productInputDto.ToDate,
                Picture=productInputDto.Picture,
             //   Price=productInputDto.Price,
                IsRemoved=productInputDto.IsRemoved,
                ShopId=productInputDto.ShopId,
                Status=productInputDto.Status,
                SuitableFor=productInputDto.SuitableFor,   
                CategoryId =productInputDto.CategoryId,
            };

            await _context.Products.AddAsync(product);
            var result = await _context.SaveChangesAsync();
            if (result != 0)
                return product.Id;

            return 0;
        }
        public async Task<int?> Delete(int? Id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(Id);
            product.IsRemoved = true;
            int result = await _context.SaveChangesAsync();
            if (result != 0)
                return product.Id;

            return 0;
        }
        public async Task<int?> Update(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(productInputDto.Id);

            product.Id = productInputDto.Id;
            product.ProductName = productInputDto.ProductName;
            product.NetWeight = productInputDto.NetWeight;
            product.PackageWeight = productInputDto.PackageWeight;
            product.Discription = productInputDto.Discription;
            product.Auction = productInputDto.Auction;
            product.Count = productInputDto.Count;
            product.FromDate = productInputDto.FromDate;
            product.ToDate = productInputDto.ToDate;
          //  product.Price = productInputDto.Price;
            product.IsRemoved = productInputDto.IsRemoved;
            product.ShopId = productInputDto.ShopId;
            product.Picture = productInputDto.Picture;
            product.Status = productInputDto.Status;
            product.SuitableFor = productInputDto.SuitableFor;
            product.CategoryId = productInputDto.CategoryId;
            int result = await _context.SaveChangesAsync();
            if (result != 0)
                return product.Id;

            return 0;
        }
        public async Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var productList = await _context.Products.AsNoTracking().Select(p => new ProductOutputDto
            {
                Id = p.Id,  
                ProductName = p.ProductName,
                NetWeight = p.NetWeight,
                PackageWeight = p.PackageWeight,
                Discription = p.Discription,
                Auction = p.Auction,
                Count = p.Count,
                FromDate = p.FromDate,
                ToDate = p.ToDate,
                Picture = p.Picture,
                Price = p.Price,
                IsRemoved = p.IsRemoved,
                ShopId = p.ShopId,
                Status = p.Status,
                SuitableFor = p.SuitableFor,
                CategoryId = p.CategoryId,
                Category=p.Category,
                Shop=p.Shop,
                Solds=p.Solds

            }).ToListAsync();
            return productList;
        }
        public async Task<ProductOutputDto> GetById(int? Id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
            var ProductDto = new ProductOutputDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                NetWeight = product.NetWeight,
                PackageWeight = product.PackageWeight,
                Discription = product.Discription,
                Auction = product.Auction,
                Count = product.Count,
                FromDate = product.FromDate,
                ToDate = product.ToDate,
                Picture = product.Picture,
                Price = product.Price,
                IsRemoved = product.IsRemoved,
                ShopId = product.ShopId,
                Status = product.Status,
                SuitableFor = product.SuitableFor,
                CategoryId = product.CategoryId,
                Category = product.Category,
                Shop = product.Shop,
                Solds = product.Solds

            };
            return ProductDto;
        }
        public async Task<List<ProductOutputDto>> GetByShopId(int? ShopId, CancellationToken cancellationToken)
        {
            var productList = await _context.Products.AsNoTracking().Where(p => p.ShopId ==ShopId).Select(p=> new ProductOutputDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                NetWeight = p.NetWeight,
                PackageWeight = p.PackageWeight,
                Discription = p.Discription,
                Auction = p.Auction,
                Count = p.Count,
                FromDate = p.FromDate,
                ToDate = p.ToDate,
                Picture = p.Picture,
                Price = p.Price,
                IsRemoved = p.IsRemoved,
                ShopId = p.ShopId,
                Status = p.Status,
                SuitableFor = p.SuitableFor,
                CategoryId = p.CategoryId,
                Category = p.Category,
                Shop = p.Shop,
                Solds = p.Solds

            }).ToListAsync();
            return productList;
        }
        public async Task<List<ProductOutputDto>> GetByCategoryId(int? CategoryId, CancellationToken cancellationToken)
        {
            var productList = await _context.Products.AsNoTracking().Where(p => p.CategoryId == CategoryId).Select(p => new ProductOutputDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                NetWeight = p.NetWeight,
                PackageWeight = p.PackageWeight,
                Discription = p.Discription,
                Auction = p.Auction,
                Count = p.Count,
                FromDate = p.FromDate,
                ToDate = p.ToDate,
                Picture = p.Picture,
                Price = p.Price,
                IsRemoved = p.IsRemoved,
                ShopId = p.ShopId,
                Status = p.Status,
                SuitableFor = p.SuitableFor,
                CategoryId = p.CategoryId,
                Category = p.Category,
                Shop = p.Shop,
                Solds = p.Solds

            }).ToListAsync();
            return productList;
        }
       
        #endregion
    }
}
