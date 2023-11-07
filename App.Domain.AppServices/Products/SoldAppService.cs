using App.Domain.Core.Products.Contract.AppServices;
using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Products.Dtos.CommentDto;
using App.Domain.Core.Products.Dtos.ShopDto;
using App.Domain.Core.Products.Dtos.SoldDto;
using App.Domain.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Products
{
    public class SoldAppService : ISoldAppService
    {
        #region  Dependency Injection ...

        private readonly ISoldService _soldService;

        public SoldAppService(ISoldService soldService)
        {
            _soldService = soldService;
        }
        #endregion

        #region Sold AppServices Methods ...
        public async Task<string> CreateSold(SoldInputDto soldInputDto, CancellationToken cancellationToken)
        {
            int? product = await _soldService.CreateSold(soldInputDto, cancellationToken);
            if (product != 0)
                return $"Sold with id => {soldInputDto.Id} created successfuly";
            else
                return $"cant create Sold with id => {soldInputDto.Id}"; 
        }

        public async Task<string> Delete(int? Id, CancellationToken cancellationToken)
        {
            int? sold = await _soldService.Delete(Id, cancellationToken);
            if (sold != 0)
                return $"Sold with id => {Id} deleted successfuly";
            else
                return $"cant delete Sold with id => {Id}";
        }

        public async Task<string> Update(SoldInputDto soldInputDto, CancellationToken cancellationToken)
        {
            int? sold = await _soldService.Update(soldInputDto, cancellationToken);
            if (sold != 0)
                return $"Sold with id => {soldInputDto.Id} Update successfuly";
            else
                return $"cant Update Sold with id => {soldInputDto.Id}";
        }

        public async Task<List<SoldOutputDto>> GetByBuyerId(int? BuyerId, CancellationToken cancellationToken)
        {
            IEnumerable<SoldOutputDto> result = (IEnumerable<SoldOutputDto>)_soldService.GetAll(cancellationToken);
            List<SoldOutputDto> outPutResult = new List<SoldOutputDto>();
            foreach (var item in result)
            {
                if (item.BuyerId == BuyerId) outPutResult.Add(item);
            }
            return outPutResult; ;
        }
        public async Task<SoldOutputDto> GetById(int? GeById, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SoldOutputDto>> GetByProductId(int? ProductId, CancellationToken cancellationToken)
        {
            IEnumerable<SoldOutputDto> result = (IEnumerable<SoldOutputDto>)_soldService.GetAll(cancellationToken);
            List<SoldOutputDto> outPutResult = new List<SoldOutputDto>();
            foreach (var item in result)
            {
                if (item.BuyerId == ProductId) outPutResult.Add(item);
            }
            return outPutResult; ;
        }
        public async Task<List<SoldOutputDto>> GetAll(CancellationToken cancellationToken)
         => await _soldService.GetAll(cancellationToken);

        

    
        #endregion




    }
}
