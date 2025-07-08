using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOC.SaleAndPurchase.PurchaseAppService;
public interface IPurchaseAppService
{
    Task<List<PurchaseDto>> GetAllAsync();
    Task<PurchaseDto> GetAsync(Guid id);
    Task<PurchaseDto> CreateAsync(CreateUpdatePurchaseDto input);
    Task<PurchaseDto> UpdateAsync(Guid id, CreateUpdatePurchaseDto input);
    Task DeleteAsync(Guid id);
}

