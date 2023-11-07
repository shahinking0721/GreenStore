using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Dtos.CategoryDto;
using App.Domain.Core.Products.Dtos.CommentDto;
using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Core.Products.Dtos.ShopDto;
using App.Domain.Core.Products.Entities;
using App.Infra.Data.SqlServer.Ef.DbCTX;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Products
{
    public class ShopRepository : IShopRepository
    {
        #region Dependency Injection ...
        private readonly GreenStoreDbContext _context;

        public ShopRepository(GreenStoreDbContext context)
        {
            _context = context;
        }
        #endregion

        #region  Shop Repository Methods...

        public async Task<int?> Add(ShopInputDto shopInputDto, CancellationToken cancellationToken)
        {
            Shop shop = new Shop
            {
                Id = shopInputDto.Id,
                //Address = shopInputDto.Address,
                //City = shopInputDto.City,
                IsRemoved = shopInputDto.IsRemoved,
                Message = shopInputDto.Message,
                Picture = shopInputDto.Picture,
                ShopName = shopInputDto.ShopName,
                Sign = shopInputDto.Sign,
                //SellerId = shopInputDto.SellerId,
                Wage = shopInputDto.Wage
            };
            await _context.Shops.AddAsync(shop);
            var result = await _context.SaveChangesAsync();
            if (result != 0)
                return shop.Id;
            return 0;
        }

        public async Task<int?> Delete(int? Id, CancellationToken cancellationToken)
        {
            var shop = await _context.Shops.FindAsync(Id);
            shop.IsRemoved = true;
            int result = await _context.SaveChangesAsync();
            if (result != 0)
                return shop.Id;
            return 0;
        }

        public async Task<List<ShopOutputDto>> GetAll(CancellationToken cancellationToken)
        {

            var shopList = await _context.Shops.AsNoTracking().Select(s => new ShopOutputDto
            {
                Id = s.Id,
               ShopName=s.ShopName,
               Sign = s.Sign,   
               IsRemoved = s.IsRemoved,
               Message = s.Message,
               //City = s.City,
               //Address = s.Address,
               //Products = s.Products,
               //Picture = s.Picture,
               //Seller = s.Seller,
               //SellerId = s.SellerId,
               Wage = s.Wage    
            }).ToListAsync();
            return shopList;
        }

        public async Task<ShopOutputDto> GetById(int? Id, CancellationToken cancellationToken)
        {
            var shop = await _context.Shops.FirstOrDefaultAsync(s => s.Id == Id);
            var ShopDto = new ShopOutputDto
            {
                Id = shop.Id,
                IsRemoved=shop.IsRemoved,
                Products=shop.Products,
                //Wage=shop.Wage,
                //SellerId=shop.SellerId,
                //Address=shop.Address,
                //City=shop.City,
                //Message=shop.Message,
                //Picture=shop.Picture,
                //Seller = shop.Seller,
                ShopName =shop.ShopName,
                Sign =shop.Sign
            };
            return ShopDto;
        }

        public async Task<ShopOutputDto> GetBySellerId(int? SellerId, CancellationToken cancellationToken)
        {
            var shopDto = await _context.Shops.FirstOrDefaultAsync(p => p.Id == SellerId);
            var Seller = new ShopOutputDto
            {
                Id = shopDto.Id,
                IsRemoved = shopDto.IsRemoved,
                Products = shopDto.Products,
                Wage = shopDto.Wage,
                //SellerId = shopDto.SellerId,
                //Address = shopDto.Address,
                //City = shopDto.City,
                Message = shopDto.Message,
                Picture = shopDto.Picture,
              //  Seller = shopDto.Seller,
                ShopName = shopDto.ShopName,
                Sign = shopDto.Sign
            };
            return Seller;
        }
        public async Task<int?> Update(ShopInputDto shopInputDto, CancellationToken cancellationToken)
        {
            var shop = await _context.Shops.FindAsync(shopInputDto.Id);
            shop.Id = shopInputDto.Id;
            shop.ShopName = shopInputDto.ShopName;
            shop.Message = shopInputDto.Message;
            //shop.Address = shopInputDto.Address;
            //shop.City = shopInputDto.City;
            shop.Sign = shopInputDto.Sign;
            shop.Picture = shopInputDto.Picture;
            shop.IsRemoved = shopInputDto.IsRemoved;
           // shop.SellerId = shopInputDto.SellerId;
           // shop.Wage = shopInputDto.SellerId;
             int result = await _context.SaveChangesAsync();
            if (result != 0)
                return shop.Id;
            return 0;
        }
        #endregion
    }
}
