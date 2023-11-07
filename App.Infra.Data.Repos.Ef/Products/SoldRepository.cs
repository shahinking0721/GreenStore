using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Core.Products.Dtos.ShopDto;
using App.Domain.Core.Products.Dtos.SoldDto;
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
    public class SoldRepository: ISoldRepository
    {
        #region Dependency Injection ...
        private readonly GreenStoreDbContext _context;

        public SoldRepository(GreenStoreDbContext context)
        {
            _context = context;
        }
        #endregion

        #region  Sold Repository Methods...
        public async Task<int?> Add(SoldInputDto soldInputDto, CancellationToken cancellationToken)
        {
            Sold sold = new Sold
            {
                Id = soldInputDto.Id,
                IsRemoved = soldInputDto.IsRemoved,
                BuyerId = soldInputDto.BuyerId,
                ProductId = soldInputDto.ProductId,
            };
            await _context.Sold.AddAsync(sold);
            var result = await _context.SaveChangesAsync();
            if (result != 0)
                return sold.Id;
            return 0;
        }
        public async Task<int?> Delete(int? Id, CancellationToken cancellationToken)
        {
            var sold = await _context.Sold.FindAsync(Id);
            sold.IsRemoved = true;
            int result = await _context.SaveChangesAsync();
            if (result != 0)
                return sold.Id;
            return 0;
        }
        public async Task<List<SoldOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var soldList = await _context.Sold.AsNoTracking().Select(s => new SoldOutputDto
            {
                Id = s.Id,
                ProductId = s.ProductId,
                IsRemoved = s.IsRemoved,
                BuyerId = s.BuyerId,
                //Buyer = s.Buyer,
                Product = s.Product
            }).ToListAsync();
            return soldList;
        }
        public async Task<SoldOutputDto> GetById(int? Id, CancellationToken cancellationToken)
        {
            var sold = await _context.Sold.FirstOrDefaultAsync(s => s.Id == Id);
            var SoldDto = new SoldOutputDto
            {
                Id = sold.Id,
                BuyerId=sold.BuyerId,
                ProductId=sold.ProductId,
                IsRemoved = sold.IsRemoved,
                Product=sold.Product,
                //Buyer=sold.Buyer,
            };
            return SoldDto;
        }
        public async Task<List<SoldOutputDto>> GetByBuyerId(int? BuyerId, CancellationToken cancellationToken)
        {
            var soldList = await _context.Sold.AsNoTracking().Where(p => p.BuyerId == BuyerId).Select(p => new SoldOutputDto
            {
                Id = p.Id,
                BuyerId = p.BuyerId,
                ProductId = p.ProductId,
                IsRemoved = p.IsRemoved,
              //  Buyer = p.Buyer,
                Product = p.Product
            }).ToListAsync();
            return soldList;
        }
        public async Task<int?> Update(SoldInputDto soldInputDto, CancellationToken cancellationToken)
        {
            var sold = await _context.Sold.FindAsync(soldInputDto.Id);
            sold.Id = soldInputDto.Id;
            sold.BuyerId = soldInputDto.BuyerId;
            sold.ProductId = soldInputDto.ProductId;
            sold.IsRemoved = soldInputDto.IsRemoved;
            int result = await _context.SaveChangesAsync();
            if (result != 0)
                return sold.Id;
            return 0;
        }

        #endregion
    }
}
