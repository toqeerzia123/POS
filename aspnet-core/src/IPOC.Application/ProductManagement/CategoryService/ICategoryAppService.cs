using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using IPOC.ProductManagement.BarcodeService;

namespace IPOC.ProductManagement.CategoryService;
public interface ICategoryAppService : IApplicationService
{
    Task<CategoryDto> GetAsync(Guid id);
    Task<List<CategoryDto>> GetAllAsync();
    Task<List<CategoryDto>> GetAllParentsAsync();
    Task<List<CategoryDto>> GetClieldAsync(Guid parentId);
    Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input);
    Task<CategoryDto> UpdateAsync(Guid id, CreateUpdateCategoryDto input);
    Task DeleteAsync(Guid id);
    Task<List<CategoryTreeNodeDto>> GetAllCategoryTreeAsync();



}

