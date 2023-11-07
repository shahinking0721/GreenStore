using App.Domain.Core.Products.Dtos.BuyerDto;
using App.Domain.Core.Products.Dtos.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.AppServices
{
    public interface IBuyerAppService
    {
        Task<string> CreateBuyer(BuyerInputDto buyerInputDto, CancellationToken cancellationToken);
        Task<string> Update(BuyerInputDto buyerInputDto, CancellationToken cancellationToken);
        Task<string> Delete(int Id, CancellationToken cancellationToken);
        Task<List<BuyerOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<BuyerOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
