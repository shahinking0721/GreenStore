using App.Domain.Core.Products.Dtos.BuyerDto;
using App.Domain.Core.Products.Dtos.SellerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.AppServices
{
    public interface ISellerAppService
    {
        Task<string> CreateSeller(SellerInputDto sellerInputDto, CancellationToken cancellationToken);
        Task<string> Update(SellerInputDto sellerInputDto, CancellationToken cancellationToken);
        Task<string> Delete(int Id, CancellationToken cancellationToken);
        Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<SellerOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
