using App.Domain.Core.Products.Dtos.AuctionDto;
using App.Domain.Core.Products.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.AppServices
{
    public interface IAuctionAppService
    {
        Task<string> CreateAuction(AuctionInputDto auctionInputDto, CancellationToken cancellationToken);
        Task<string> Update(AuctionInputDto auctionInputDto, CancellationToken cancellationToken);
        Task<string> Delete(int Id, CancellationToken cancellationToken);
        Task<List<AuctionOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<AuctionOutputDto> GetById(int Id, CancellationToken cancellationToken);
       
    }
}
