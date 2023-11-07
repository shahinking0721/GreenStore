using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Dtos.AuctionDto;
using App.Domain.Core.Products.Dtos.ProductDto;
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
    internal class AuctionRepository : IAuctionRepository
    {
        #region Dependency Injection ...
        private readonly GreenStoreDbContext _context;

        public AuctionRepository(GreenStoreDbContext context)
        {
            _context = context;
        }
        #endregion

        #region  Auction Repository Methods...
        public async Task<int?> Add(AuctionInputDto auctionInputDto, CancellationToken cancellationToken)
        {
            Auction auction = new Auction
            {
                Id = auctionInputDto.Id,
                ProposedPrice = auctionInputDto.ProposedPrice,
                DateOfPropose = auctionInputDto.DateOfPropose,
                IsRemoved = false,
                BuyerId = auctionInputDto.BuyerId,
                ProductId = auctionInputDto.ProductId,
            };
            await _context.Auctions.AddAsync(auction);
            var result = await _context.SaveChangesAsync();
            if (result != 0)
                return auction.Id;
            return 0;
        }

        public async Task<int?> Delete(int? Id, CancellationToken cancellationToken)
        {
            var auction = await _context.Auctions.FindAsync(Id);
            auction.IsRemoved = true;
            int result = await _context.SaveChangesAsync();
            if (result != 0)
                return auction.Id;
            return 0;
        }

        public async Task<List<AuctionOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var auctionsList = await _context.Auctions.AsNoTracking().Select(a => new AuctionOutputDto
            {
                Id = a.Id,
               // Buyer = a.Buyer,
                ProductId = a.ProductId,
                BuyerId = a.BuyerId,
                IsRemoved = a.IsRemoved,
                DateOfPropose = a.DateOfPropose,
                ProposedPrice = a.ProposedPrice,
                Product = a.Product
            }).ToListAsync();
            return auctionsList;
        }

        public async Task<AuctionOutputDto> GetById(int? Id, CancellationToken cancellationToken)
        {
            var auction = await _context.Auctions.FirstOrDefaultAsync(a => a.Id == Id);
            var auctionDto = new AuctionOutputDto
            {
                Id = auction.Id,
                ProposedPrice = auction.ProposedPrice,
                Product = auction.Product,
                IsRemoved = auction.IsRemoved,
                DateOfPropose = auction.DateOfPropose,
                BuyerId = auction.BuyerId,
                ProductId = auction.ProductId,
               // Buyer = auction.Buyer
            };
            return auctionDto;
        }

        public async Task<int?> Update(AuctionInputDto auctionInputDto, CancellationToken cancellationToken)
        {
            var auction = await _context.Auctions.FindAsync(auctionInputDto.Id);

            auction.Id = auctionInputDto.Id;
            auction.ProductId = auctionInputDto.ProductId;
            auction.ProposedPrice = auctionInputDto.ProposedPrice;
            auction.DateOfPropose = auctionInputDto.DateOfPropose;
            auction.BuyerId = auctionInputDto.BuyerId;
            auction.IsRemoved = auctionInputDto.IsRemoved;
            int result = await _context.SaveChangesAsync();
            if (result != 0)
                return auction.Id;
            return 0;
        }
        #endregion
    }
}
