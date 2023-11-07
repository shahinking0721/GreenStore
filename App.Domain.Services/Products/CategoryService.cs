using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Products.Dtos.CategoryDto;
using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Products
{
    public class CategoryService : ICategoryService
    {
        #region Dependency Injection ...
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        #endregion

        #region Category Services Methods ...
        public async Task<int?> CreateCategory(CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
         => await _categoryRepository.Add(categoryInputDto, cancellationToken);

        public async Task<int?> Delete(int? Id, CancellationToken cancellationToken)
           => await _categoryRepository.Delete(Id, cancellationToken);

        public async Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
        => await _categoryRepository.GetAll(cancellationToken);

        public async Task<CategoryOutputDto> GetById(int? Id, CancellationToken cancellationToken)
        => await _categoryRepository.GetById(Id, cancellationToken);

        public async Task<int?> Update(CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
            => await _categoryRepository.Update(categoryInputDto, cancellationToken);
        #endregion
    }
}
