using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Core.Products.Dtos.SoldDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.AppServices
{
    public interface ISoldAppService
    {
        Task<string> CreateSold(SoldInputDto soldInputDto, CancellationToken cancellationToken);
        Task<string> Update(SoldInputDto soldInputDto, CancellationToken cancellationToken);
        Task<string> Delete(int? Id, CancellationToken cancellationToken);
        Task<List<SoldOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<List<SoldOutputDto>> GetByBuyerId(int? IBuyerId, CancellationToken cancellationToken);
        Task<List<SoldOutputDto>> GetByProductId(int? IBuyerId, CancellationToken cancellationToken);
        Task<SoldOutputDto> GetById(int? GeById, CancellationToken cancellationToken);

    }
}
