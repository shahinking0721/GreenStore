using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Dtos.CategoryDto;
using App.Domain.Core.Products.Dtos.ProductDto;
using App.Domain.Core.Products.Entities;
using App.Infra.Data.SqlServer.Ef.DbCTX;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Products
{
    public class CategoryRepository : ICategoryRepository
    {

        #region  #region Dependency Injection ...
        private readonly GreenStoreDbContext _context;

        public CategoryRepository(GreenStoreDbContext context)
        {
            _context = context;
        }
        #endregion

        #region  #region Category Repository Methods...
        public async Task<int?> Add(CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
        {
            Category category = new Category
            {
              Id = categoryInputDto.Id,
              CategoryName= categoryInputDto.CategoryName,
             //   CategoryPicture = categoryInputDto.CategoryPicture,
              IsRemoved=false,    
            };
            await _context.Categories.AddAsync(category);
            var result = await _context.SaveChangesAsync();
            if (result != 0)
                return category.Id;
            return 0;
        }
        public async Task<int?> Delete(int? Id, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(Id);
            category.IsRemoved = true;
            int result = await _context.SaveChangesAsync();
            if (result != 0)
                return category.Id;

            return 0;
        }

        public async Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var categoryList = await _context.Categories.AsNoTracking().Select(p => new CategoryOutputDto
            {
              Id= p.Id,
            //  Products= p.Products,
              IsRemoved = false,
             //   CategoryPicture = p.CategoryPicture,
              CategoryName = p.CategoryName

            }).ToListAsync();
            return categoryList;
        }

        public async Task<CategoryOutputDto> GetById(int? Id, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == Id);
            var categoryDto = new CategoryOutputDto
            {
                Id = category.Id,
                //Products = category.Products,
                //CategoryName = category.CategoryName,
                //CategoryPicture = category.CategoryPicture,
                //IsRemoved = category.IsRemoved
            };
            return categoryDto;
        }
        public async Task<int?> Update(CategoryInputDto categoryInputDto, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(categoryInputDto.Id);
            category.Id = categoryInputDto.Id;
            category.CategoryName = categoryInputDto.CategoryName;
           // category.CategoryPicture = categoryInputDto.CategoryPicture;
            int result = await _context.SaveChangesAsync();
            if (result != 0)
                return category.Id;
            return 0;
        }
        #endregion
    }
}
