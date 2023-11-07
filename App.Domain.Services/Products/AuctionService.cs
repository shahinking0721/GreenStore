using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Products.Dtos.AuctionDto;
using App.Domain.Core.Products.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Products
{
    public class AuctionService : IAuctionService
    {
        #region Dependency Injection ...
        private readonly IAuctionRepository _auctionRepository;
        public AuctionService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }
        #endregion

        #region Auction Services Methods ...
        public async Task<int?> CreateAuction(AuctionInputDto auctionInputDto, CancellationToken cancellationToken)
        => await _auctionRepository.Add(auctionInputDto, cancellationToken);

        public async Task<int?> Delete(int? Id, CancellationToken cancellationToken)
        => await _auctionRepository.Delete(Id, cancellationToken);

        public async Task<List<AuctionOutputDto>> GetAll(CancellationToken cancellationToken)
        => await _auctionRepository.GetAll(cancellationToken);

        public async Task<AuctionOutputDto> GetById(int Id, CancellationToken cancellationToken)
          => await _auctionRepository.GetById(Id, cancellationToken);

        public async Task<int?> Update(AuctionInputDto auctionInputDto, CancellationToken cancellationToken)
        => await _auctionRepository.Update(auctionInputDto, cancellationToken);
        #endregion
    }
}
