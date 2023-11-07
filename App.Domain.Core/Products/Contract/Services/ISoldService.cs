using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Core.Products.Dtos.SoldDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.Services
{
    public interface ISoldService
    {
        Task<int?> CreateSold(SoldInputDto soldInputDto, CancellationToken cancellationToken);
        Task<int?> Update(SoldInputDto soldInputDto, CancellationToken cancellationToken);
        Task<int?> Delete(int? Id, CancellationToken cancellationToken);
        Task<List<SoldOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<SoldOutputDto> GetById(int? Id, CancellationToken cancellationToken);

    }
}
