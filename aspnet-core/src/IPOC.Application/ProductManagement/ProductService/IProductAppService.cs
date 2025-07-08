using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;

namespace IPOC.ProductManagement.ProductService;
public interface IProductAppService : IApplicationService
{
    Task<ProductDto> GetAsync(Guid id);
    Task<List<ProductDto>> GetAllAsync();
    Task<ProductDto> CreateAsync(CreateUpdateProductDto input);
    Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input);
    Task DeleteAsync(Guid id);
}

