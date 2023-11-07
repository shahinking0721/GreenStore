using App.Domain.Core.Products.Contract.AppServices;
using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Products.Dtos.AuctionDto;
using App.Domain.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Products
{
    public class AuctionAppService : IAuctionAppService
    {
        #region Dependency Injection ...

        private readonly IAuctionService _auctionService;

        public AuctionAppService(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }
        #endregion

        #region Auction AppServices Methods ...
        public async Task<string> CreateAuction(AuctionInputDto auctionInputDto, CancellationToken cancellationToken)
        {
            int ?auction = await _auctionService.CreateAuction(auctionInputDto, cancellationToken);
            if (auction != 0)
                return $"auction with id = {auctionInputDto.Id} created successfuly";
            else
                return $"sorry! cant create auction with id = {auctionInputDto.Id}";
        }
        public async Task<string> Update(AuctionInputDto auctionInputDto, CancellationToken cancellationToken)
        {
            int? auction = await _auctionService.Update(auctionInputDto, cancellationToken);
            if (auction != 0)
                return $"auction with id = {auctionInputDto.Id} update successfuly";
            else
                return $"sorry! cant update auction with id = {auctionInputDto.Id}";
        }

        public async Task<string> Delete(int Id, CancellationToken cancellationToken)
        {
            int? auction = await _auctionService.Delete(Id, cancellationToken);
            if (auction != 0)
                return $"auction with id = {Id} deleted successfuly";
            else
                return $"sorry! cant delete auction with id = {Id}";
        }

        public async Task<List<AuctionOutputDto>> GetAll(CancellationToken cancellationToken)
          => await _auctionService.GetAll(cancellationToken);

        public async Task<AuctionOutputDto> GetById(int Id, CancellationToken cancellationToken)
             => await _auctionService.GetById(Id, cancellationToken);

        #endregion
    }
}
