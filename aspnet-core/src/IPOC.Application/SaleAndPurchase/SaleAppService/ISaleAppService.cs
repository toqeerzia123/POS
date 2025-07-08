using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;

namespace IPOC.SaleAndPurchase.SaleAppService;
public interface ISaleAppService : IApplicationService
{
    Task<List<SaleDto>> GetAllAsync();
    Task<SaleDto> GetAsync(Guid id);
    Task<SaleDto> CreateAsync(CreateUpdateSaleDto input);
    Task<SaleDto> UpdateAsync(Guid id, CreateUpdateSaleDto input);
    Task DeleteAsync(Guid id);
}

