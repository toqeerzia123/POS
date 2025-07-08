using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using IPOC.SaleAndPurchase.PurchaseAppService;

namespace IPOC.SaleAndPurchase.PurchaseItemAppService;
public interface IPurchaseItemAppService : IApplicationService
{
  //  Task<List<PurchaseItemDto>> GetAllAsync();
    Task<PurchaseItemDto> GetAsync(Guid id);
    Task<PurchaseItemDto> CreateAsync(CreateUpdatePurchaseItemDto input);
    Task<PurchaseItemDto> UpdateAsync(Guid id, CreateUpdatePurchaseItemDto input);
    Task DeleteAsync(Guid id);
}

