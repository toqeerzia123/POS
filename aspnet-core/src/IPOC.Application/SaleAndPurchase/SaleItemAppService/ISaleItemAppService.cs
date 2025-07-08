using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using IPOC.SaleAndPurchase.SaleAppService;

namespace IPOC.SaleAndPurchase.SaleItemAppService;
public interface ISaleItemAppService : IApplicationService
{
    Task<List<SaleItemDto>> GetAllAsync();
    Task<SaleItemDto> GetAsync(Guid id);
    Task<SaleItemDto> CreateAsync(CreateUpdateSaleItemDto input);
    Task<SaleItemDto> UpdateAsync(Guid id, CreateUpdateSaleItemDto input);
    Task DeleteAsync(Guid id);
}
