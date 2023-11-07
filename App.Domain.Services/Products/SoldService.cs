using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Products.Dtos.ShopDto;
using App.Domain.Core.Products.Dtos.SoldDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.Services.Products
{
    public class SoldService : ISoldService
    {
        #region Dependency Injection ...
        private readonly ISoldRepository _soldRepository;
        public SoldService(ISoldRepository soldRepository)
        {
            this._soldRepository = soldRepository;
        }
        #endregion

        #region Sold Services Methods ...
        public async Task<int?> CreateSold(SoldInputDto soldInputDto, CancellationToken cancellationToken)
          => await _soldRepository.Add(soldInputDto, cancellationToken);

        public async Task<int?> Delete(int? Id, CancellationToken cancellationToken)
          => await _soldRepository.Delete(Id, cancellationToken);

        public async Task<List<SoldOutputDto>> GetAll(CancellationToken cancellationToken)
          => await _soldRepository.GetAll(cancellationToken);


        public async Task<SoldOutputDto> GetById(int? Id, CancellationToken cancellationToken)
          => await _soldRepository.GetById(Id,cancellationToken);

        public async Task<int?> Update(SoldInputDto soldInputDto, CancellationToken cancellationToken)
          => await _soldRepository.Update(soldInputDto, cancellationToken);
        #endregion

    }
}
