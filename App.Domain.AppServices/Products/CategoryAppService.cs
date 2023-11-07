using App.Domain.Core.Products.Contract.AppServices;
using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Products.Dtos.CategoryDto;
using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Products
{
    public class CategoryAppService : ICategoryAppService
    {
        #region  #region Dependency Injection ...

        private readonly ICategoryService _categoryService;

        public CategoryAppService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        #endregion

        #region Category AppServices Methods ...
        public async Task<string> CreateCategory(CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
        {
            int? product = await _categoryService.CreateCategory(categoryInputDto, cancellationToken);
            if (product != 0)
                return $"product with titleid = {categoryInputDto.CategoryName} created successfuly";
            else
                return $"cant create product with titleid = {categoryInputDto.CategoryName}";
        }

        public async Task<string> Delete(int Id, CancellationToken cancellationToken)
        {
            int? result = await _categoryService.Delete(Id, cancellationToken);
            if (result == 1)
                return $"category with id = {Id} deleted successfuly";
            else
                return $"category with id = {Id} not found";
        }

        public async Task<string> Update(CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
        {
            int? result = await _categoryService.Update(categoryInputDto, cancellationToken);
            if (result != 0)
                return $"category with id = {categoryInputDto.Id} edited successfuly";
            else
                return $"category with id = {categoryInputDto.Id} not edited";
        }
      
        public async Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
        => await _categoryService.GetAll(cancellationToken);

        public async Task<CategoryOutputDto> GetById(int Id, CancellationToken cancellationToken)
          => await _categoryService.GetById(Id, cancellationToken);

       
        #endregion
    }
}
