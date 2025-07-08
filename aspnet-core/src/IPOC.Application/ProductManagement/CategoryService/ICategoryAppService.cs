using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;

namespace IPOC.ProductManagement.CategoryService;
public interface ICategoryAppService : IApplicationService
{
    Task<CategoryDto> GetAsync(Guid id);
    Task<List<CategoryDto>> GetAllAsync();
    Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input);
    Task<CategoryDto> UpdateAsync(Guid id, CreateUpdateCategoryDto input);
    Task DeleteAsync(Guid id);
}

