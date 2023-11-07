using App.Domain.Core.Products.Dtos.CategoryDto;
using App.Domain.Core.Products.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contract.Services
{
    public interface ICategoryService
    {
        Task<int?> CreateCategory(CategoryInputDto categoryInputDto, CancellationToken cancellationToken);
        Task<int?> Update(CategoryInputDto categoryInputDto, CancellationToken cancellationToken);
        Task<int?> Delete(int? Id, CancellationToken cancellationToken);
        Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<CategoryOutputDto> GetById(int? Id, CancellationToken cancellationToken);
    }
}
